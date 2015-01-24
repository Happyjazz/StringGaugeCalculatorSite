using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StringCalc : System.Web.UI.Page
{
    DataTable _frequenciesTable;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateFrequencyDropdowns();
            ResetFrequencyDropDowns();
            ResetTension();
            ResetScale();
            ResetNumberOfStrings();
        }

        UpdateUnitWeightAndGauge();
        
    }

    #region Buttons
    protected void buttonCalculate_Click(object sender, EventArgs e)
    {
        UpdateUnitWeightAndGauge();
    }
    protected void buttonReset_Click(object sender, EventArgs e)
    {
        ResetFrequencyDropDowns();
        ResetTension();
        UpdateUnitWeightAndGauge();
    }
    #endregion
    #region Actions
    protected void radio4Strings_CheckedChanged(object sender, EventArgs e)
    {
        labelString6.Visible = false;
        ddString6.Visible = false;
        txtStringFreq6.Visible = false;
        txtUnitWeight6.Visible = false;
        txtStringGauge6.Visible = false;

        labelString1.Visible = false;
        ddString1.Visible = false;
        txtStringFreq1.Visible = false;
        txtUnitWeight1.Visible = false;
        txtStringGauge1.Visible = false;

        labelString2.Text = "String 1";
        labelString3.Text = "String 2";
        labelString4.Text = "String 3";
        labelString5.Text = "String 4";

        UpdateUnitWeightAndGauge();
    }
    protected void radio5Strings_CheckedChanged(object sender, EventArgs e)
    {
        labelString6.Visible = true;
        ddString6.Visible = true;
        txtStringFreq6.Visible = true;
        txtUnitWeight6.Visible = true;
        txtStringGauge6.Visible = true;

        labelString1.Visible = false;
        ddString1.Visible = false;
        txtStringFreq1.Visible = false;
        txtUnitWeight1.Visible = false;
        txtStringGauge1.Visible = false;

        labelString2.Text = "String 1";
        labelString3.Text = "String 2";
        labelString4.Text = "String 3";
        labelString5.Text = "String 4";
        labelString6.Text = "String 5";

        UpdateUnitWeightAndGauge();
    }
    protected void radio6Strings_CheckedChanged(object sender, EventArgs e)
    {
        labelString6.Visible = true;
        ddString6.Visible = true;
        txtStringFreq6.Visible = true;
        txtUnitWeight6.Visible = true;
        txtStringGauge6.Visible = true;

        labelString1.Visible = true;
        ddString1.Visible = true;
        txtStringFreq1.Visible = true;
        txtUnitWeight1.Visible = true;
        txtStringGauge1.Visible = true;

        labelString1.Text = "String 1";
        labelString2.Text = "String 2";
        labelString3.Text = "String 3";
        labelString4.Text = "String 4";
        labelString5.Text = "String 5";
        labelString6.Text = "String 6";

        UpdateUnitWeightAndGauge();
    }
    protected void radioFannedFret_CheckedChanged(object sender, EventArgs e)
    {
        TxtScaleMax.Visible = true;
        UpdateUnitWeightAndGauge();
    }
    protected void radioStandardScale_CheckedChanged(object sender, EventArgs e)
    {
        TxtScaleMax.Visible = false;
        UpdateUnitWeightAndGauge();
    }

    protected void ddTension_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddTension.SelectedValue) == 0)
        {
            txtTension.Enabled = true;
        }
        else
        {
            txtTension.Enabled = false;
        }
        txtTension.Text = Convert.ToString(ddTension.SelectedItem.Value);
        UpdateUnitWeightAndGauge();
    }
    protected void ddString6_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddString6.SelectedValue) == 0)
        {
            txtStringFreq6.Enabled = true;
        }
        else
        {
            txtStringFreq6.Enabled = false;
        }
        txtStringFreq6.Text = Convert.ToString(ddString6.SelectedItem.Value);
        UpdateUnitWeightAndGauge();
    }
    protected void ddString5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddString5.SelectedValue) == 0)
        {
            txtStringFreq5.Enabled = true;
        }
        else
        {
            txtStringFreq5.Enabled = false;
        }
        txtStringFreq5.Text = Convert.ToString(ddString5.SelectedItem.Value);
        UpdateUnitWeightAndGauge();
    }
    protected void ddString4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddString4.SelectedValue) == 0)
        {
            txtStringFreq4.Enabled = true;
        }
        else
        {
            txtStringFreq4.Enabled = false;
        }
        txtStringFreq4.Text = ddString4.SelectedValue;
        UpdateUnitWeightAndGauge();
    }
    protected void ddString3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddString3.SelectedValue) == 0)
        {
            txtStringFreq3.Enabled = true;
        }
        else
        {
            txtStringFreq3.Enabled = false;
        }
        txtStringFreq3.Text = ddString3.SelectedValue;
        UpdateUnitWeightAndGauge();
    }
    protected void ddString2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddString2.SelectedValue) == 0)
        {
            txtStringFreq2.Enabled = true;
        }
        else
        {
            txtStringFreq2.Enabled = false;
        }
        txtStringFreq2.Text = ddString2.SelectedValue;
        UpdateUnitWeightAndGauge();
    }
    protected void ddString1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(ddString1.SelectedValue) == 0)
        {
            txtStringFreq1.Enabled = true;
        }
        else
        {
            txtStringFreq1.Enabled = false;
        }
        txtStringFreq1.Text = ddString1.SelectedValue;
        UpdateUnitWeightAndGauge();
    }
    #endregion

    #region Private Methods

    int GetNumberOfStrings()
    {
        int numberOfStrings = 4;
        if (txtStringFreq6.Visible && txtStringFreq1.Visible)
        {
            numberOfStrings = 6;
        }
        else if (txtStringFreq6.Visible && !txtStringFreq1.Visible)
        {
            numberOfStrings = 5;
        }
        return numberOfStrings;
    }

    Dictionary<TextBox, TextBox> GetPairsFreqUnitW()
    {
        Dictionary<TextBox, TextBox> textboxPairsFreqUnitW = new Dictionary<TextBox, TextBox>();
        textboxPairsFreqUnitW.Add(txtStringFreq6, txtUnitWeight6);
        textboxPairsFreqUnitW.Add(txtStringFreq5, txtUnitWeight5);
        textboxPairsFreqUnitW.Add(txtStringFreq4, txtUnitWeight4);
        textboxPairsFreqUnitW.Add(txtStringFreq3, txtUnitWeight3);
        textboxPairsFreqUnitW.Add(txtStringFreq2, txtUnitWeight2);
        textboxPairsFreqUnitW.Add(txtStringFreq1, txtUnitWeight1);
        return textboxPairsFreqUnitW;
    }
    Dictionary<TextBox, TextBox> GetPairsUnitWGauge()
    {
        Dictionary<TextBox, TextBox> textboxPairsUnitWGauge = new Dictionary<TextBox, TextBox>();
        textboxPairsUnitWGauge.Add(txtUnitWeight6, txtStringGauge6);
        textboxPairsUnitWGauge.Add(txtUnitWeight5, txtStringGauge5);
        textboxPairsUnitWGauge.Add(txtUnitWeight4, txtStringGauge4);
        textboxPairsUnitWGauge.Add(txtUnitWeight3, txtStringGauge3);
        textboxPairsUnitWGauge.Add(txtUnitWeight2, txtStringGauge2);
        textboxPairsUnitWGauge.Add(txtUnitWeight1, txtStringGauge1);
        return textboxPairsUnitWGauge;
    }

    void UpdateUnitWeightAndGauge()
    {
        CalculateAllUnitWeights();
        CalculateAllStringGauges();
    }
    void CalculateAllStringGauges()
    {
        Dictionary<TextBox, TextBox> textboxPairsUnitWGauge = GetPairsUnitWGauge();

        foreach (var pair in textboxPairsUnitWGauge)
        {
            if (!String.IsNullOrWhiteSpace(pair.Key.Text))
            {
                float temp = (float)Convert.ToDouble(pair.Key.Text);
                pair.Value.Text = GetCircleKStringGauge(temp);
            }
        }
    }
    void CalculateAllUnitWeights()  
    {
        Dictionary<TextBox, TextBox> textboxPairsFreqUnitW = GetPairsFreqUnitW();

        float tension = (float)Convert.ToDouble(txtTension.Text);
        
        float scaleInterval = (float)Convert.ToDouble(TxtScaleMax.Text) - (float)Convert.ToDouble(txtScale.Text);
        scaleInterval /= (GetNumberOfStrings() - 1);

        float scale = (float)Convert.ToDouble(TxtScaleMax.Text) + scaleInterval;

        foreach (var pair in textboxPairsFreqUnitW)
        {
            if (radioFannedFret.Checked)
            {
                if (pair.Key.Visible && pair.Value.Visible)
                {
                    scale -= scaleInterval;
                    pair.Value.Text = Convert.ToString(CalculateUnitWeight((float)Convert.ToDouble(pair.Key.Text), tension, scale));
                }
            }
            else
            {
                scale = (float)Convert.ToDouble(txtScale.Text);

                if (pair.Key.Visible && pair.Value.Visible)
                {
                    pair.Value.Text = Convert.ToString(CalculateUnitWeight((float)Convert.ToDouble(pair.Key.Text), tension, scale));
                }
            }
        }
    }

    //This methods calculates the Unit Weight from the values entered into Frequency, Tension and Scale
    float CalculateUnitWeight(float frequency, float tension, float scale)
    {
        float result = (tension * (float)386.4) / ((2 * scale * frequency) * (2 * scale * frequency));
        return result;
    }

    void PopulateFrequencyDropdowns()
    {
        _frequenciesTable = new DataTable();

        _frequenciesTable.Columns.Add("Note");
        _frequenciesTable.Columns.Add("Frequency");

        _frequenciesTable.Rows.Add("Custom", "0");
        _frequenciesTable.Rows.Add("16,35 Hz \tC0", "16,35");
        _frequenciesTable.Rows.Add("17,32 Hz \tC#0/Db0 ", "17,32");
        _frequenciesTable.Rows.Add("18,35 Hz \tD0", "18,35");
        _frequenciesTable.Rows.Add("19,45 Hz \tD#0/Eb0 ", "19,45");
        _frequenciesTable.Rows.Add("20,60 Hz \tE0", "20,6");
        _frequenciesTable.Rows.Add("21,83 Hz \tF0", "21,83");
        _frequenciesTable.Rows.Add("23,12 Hz \tF#0/Gb0 ", "23,12");
        _frequenciesTable.Rows.Add("24,50 Hz \tG0", "24,5");
        _frequenciesTable.Rows.Add("25,96 Hz \tG#0/Ab0 ", "25,96");
        _frequenciesTable.Rows.Add("27,50 Hz \tA0", "27,5");
        _frequenciesTable.Rows.Add("29,14 Hz \tA#0/Bb0 ", "29,14");
        _frequenciesTable.Rows.Add("30,87 Hz \tB0", "30,87");
        _frequenciesTable.Rows.Add("32,70 Hz \tC1", "32,7");
        _frequenciesTable.Rows.Add("34,65 Hz \tC#1/Db1 ", "34,65");
        _frequenciesTable.Rows.Add("36,71 Hz \tD1", "36,71");
        _frequenciesTable.Rows.Add("38,89 Hz \tD#1/Eb1 ", "38,89");
        _frequenciesTable.Rows.Add("41,20 Hz \tE1", "41,2");
        _frequenciesTable.Rows.Add("43,65 Hz \tF1", "43,65");
        _frequenciesTable.Rows.Add("46,25 Hz \tF#1/Gb1 ", "46,25");
        _frequenciesTable.Rows.Add("49,00 Hz \tG1", "49");
        _frequenciesTable.Rows.Add("51,91 Hz \tG#1/Ab1 ", "51,91");
        _frequenciesTable.Rows.Add("55,00 Hz \tA1", "55");
        _frequenciesTable.Rows.Add("58,27 Hz \tA#1/Bb1 ", "58,27");
        _frequenciesTable.Rows.Add("61,74 Hz \tB1", "61,74");
        _frequenciesTable.Rows.Add("65,41 Hz \tC2", "65,41");
        _frequenciesTable.Rows.Add("69,30 Hz \tC#2/Db2 ", "69,3");
        _frequenciesTable.Rows.Add("73,42 Hz \tD2", "73,42");
        _frequenciesTable.Rows.Add("77,78 Hz \tD#2/Eb2 ", "77,78");
        _frequenciesTable.Rows.Add("82,41 Hz \tE2", "82,41");
        _frequenciesTable.Rows.Add("87,31 Hz \tF2", "87,31");
        _frequenciesTable.Rows.Add("92,50 Hz \tF#2/Gb2 ", "92,5");
        _frequenciesTable.Rows.Add("98,00 Hz \tG2", "98");
        _frequenciesTable.Rows.Add("103,83 Hz \tG#2/Ab2 ", "103,83");
        _frequenciesTable.Rows.Add("110,00 Hz \tA2", "110");
        _frequenciesTable.Rows.Add("116,54 Hz \tA#2/Bb2 ", "116,54");
        _frequenciesTable.Rows.Add("123,47 Hz \tB2", "123,47");
        _frequenciesTable.Rows.Add("130,81 Hz \tC3", "130,81");
        _frequenciesTable.Rows.Add("138,59 Hz \tC#3/Db3 ", "138,59");
        _frequenciesTable.Rows.Add("146,83 Hz \tD3", "146,83");
        _frequenciesTable.Rows.Add("155,56 Hz \tD#3/Eb3 ", "155,56");
        _frequenciesTable.Rows.Add("164,81 Hz \tE3", "164,81");
        _frequenciesTable.Rows.Add("174,61 Hz \tF3", "174,61");
        _frequenciesTable.Rows.Add("185,00 Hz \tF#3/Gb3 ", "185");
        _frequenciesTable.Rows.Add("196,00 Hz \tG3", "196");
        _frequenciesTable.Rows.Add("207,65 Hz \tG#3/Ab3 ", "207,65");
        _frequenciesTable.Rows.Add("220,00 Hz \tA3", "220");
        _frequenciesTable.Rows.Add("233,08 Hz \tA#3/Bb3 ", "233,08");
        _frequenciesTable.Rows.Add("246,94 Hz \tB3", "246,94");

        ddString6.DataSource = _frequenciesTable;
        ddString6.DataTextField = "Note";
        ddString6.DataValueField = "Frequency";
        ddString6.DataBind();

        ddString5.DataSource = _frequenciesTable;
        ddString5.DataTextField = "Note";
        ddString5.DataValueField = "Frequency";
        ddString5.DataBind();
        
        ddString4.DataSource = _frequenciesTable;
        ddString4.DataTextField = "Note";
        ddString4.DataValueField = "Frequency";
        ddString4.DataBind();

        ddString3.DataSource = _frequenciesTable;
        ddString3.DataTextField = "Note";
        ddString3.DataValueField = "Frequency";
        ddString3.DataBind();
        
        ddString2.DataSource = _frequenciesTable;
        ddString2.DataTextField = "Note";
        ddString2.DataValueField = "Frequency";
        ddString2.DataBind();
        
        ddString1.DataSource = _frequenciesTable;
        ddString1.DataTextField = "Note";
        ddString1.DataValueField = "Frequency";
        ddString1.DataBind();
    }
    #endregion
    #region ResetMethods
    void ResetFrequencyDropDowns()
    {
        ddString6.SelectedValue = "30,87";
        txtStringFreq6.Enabled = false;
        txtStringFreq6.Text = ddString6.SelectedValue;

        ddString5.SelectedValue = "41,2";
        txtStringFreq5.Enabled = false;
        txtStringFreq5.Text = ddString5.SelectedValue;

        ddString4.SelectedValue = "55";
        txtStringFreq4.Enabled = false;
        txtStringFreq4.Text = ddString4.SelectedValue;

        ddString3.SelectedValue = "73,42";
        txtStringFreq3.Enabled = false;
        txtStringFreq3.Text = ddString3.SelectedValue;

        ddString2.SelectedValue = "98";
        txtStringFreq2.Enabled = false;
        txtStringFreq2.Text = ddString2.SelectedValue;

        ddString1.SelectedValue = "130,81";
        txtStringFreq1.Enabled = false;
        txtStringFreq1.Text = ddString1.SelectedValue;
    }

    void ResetTension()
    {
        ddTension.SelectedValue = "40";
        txtTension.Text = Convert.ToString(ddTension.SelectedItem.Value);
        txtTension.Enabled = false;
    }

    void ResetScale()
    {
        radioStandardScale.Checked = true;
        TxtScaleMax.Visible = false;
    }

    void ResetNumberOfStrings()
    {
        radio4Strings.Checked = true;

        labelString6.Visible = false;
        ddString6.Visible = false;
        txtStringFreq6.Visible = false;
        txtUnitWeight6.Visible = false;
        txtStringGauge6.Visible = false;

        labelString1.Visible = false;
        ddString1.Visible = false;
        txtStringFreq1.Visible = false;
        txtUnitWeight1.Visible = false;
        txtStringGauge1.Visible = false;

        labelString2.Text = "String 1";
        labelString3.Text = "String 2";
        labelString4.Text = "String 3";
        labelString5.Text = "String 4";
    }

    string GetCircleKStringGauge(float unitWeight)
    {
        string StringGauge = null;

        DataTable circleKTable = new DataTable();

        circleKTable.Columns.Add("Size");
        circleKTable.Columns.Add("UnitWeight");

        circleKTable.Rows.Add(".008 - Plain Bass String", "0,00001424");
        circleKTable.Rows.Add(".009 - Plain Bass String", "0,000018022");
        circleKTable.Rows.Add(".010 - Plain Bass String", "0,000022252");
        circleKTable.Rows.Add(".011 - Plain Bass String", "0,000026925");
        circleKTable.Rows.Add(".012 - Plain Bass String", "0,000032039");
        circleKTable.Rows.Add(".013 - Plain Bass String", "0,000037605");
        circleKTable.Rows.Add(".014 - Plain Bass String", "0,000043607");
        circleKTable.Rows.Add(".015 - Plain Bass String", "0,00005005");
        circleKTable.Rows.Add(".016 - Plain Bass String", "0,000056961");
        circleKTable.Rows.Add(".017 - Plain Bass String", "0,0000643");
        circleKTable.Rows.Add(".018 - Plain Bass String", "0,000072088");
        circleKTable.Rows.Add(".019 - Plain Bass String", "0,00008036");
        circleKTable.Rows.Add(".020 - Plain Bass String", "0,000089031");
        circleKTable.Rows.Add(".021 - Plain Bass String", "0,000098155");
        circleKTable.Rows.Add(".022 - Plain Bass String", "0,000107666");
        circleKTable.Rows.Add(".023 - Plain Bass String", "0,000117702");
        circleKTable.Rows.Add(".025 - Wound Nickel/Steel Hybrid Bass String", "0,000136054");
        circleKTable.Rows.Add(".026 - Wound Nickel/Steel Hybrid Bass String", "0,000144691");
        circleKTable.Rows.Add(".027 - Wound Nickel/Steel Hybrid Bass String", "0,000153146");
        circleKTable.Rows.Add(".028 - Wound Nickel/Steel Hybrid Bass String", "0,000161203");
        circleKTable.Rows.Add(".029 - Wound Nickel/Steel Hybrid Bass String", "0,000178551");
        circleKTable.Rows.Add(".031 - Wound Nickel/Steel Hybrid Bass String", "0,000198902");
        circleKTable.Rows.Add(".033 - Wound Nickel/Steel Hybrid Bass String", "0,000223217");
        circleKTable.Rows.Add(".035 - Wound Nickel/Steel Hybrid Bass String", "0,000249034");
        circleKTable.Rows.Add(".037 - Wound Nickel/Steel Hybrid Bass String", "0,000276237");
        circleKTable.Rows.Add(".039 - Wound Nickel/Steel Hybrid Bass String", "0,000304788");
        circleKTable.Rows.Add(".041 - Wound Nickel/Steel Hybrid Bass String", "0,000334965");
        circleKTable.Rows.Add(".043 - Wound Nickel/Steel Hybrid Bass String", "0,000366357");
        circleKTable.Rows.Add(".045 - Wound Nickel/Steel Hybrid Bass String", "0,000404956");
        circleKTable.Rows.Add(".047 - Wound Nickel/Steel Hybrid Bass String", "0,000447408");
        circleKTable.Rows.Add(".049 - Wound Nickel/Steel Hybrid Bass String", "0,000475438");
        circleKTable.Rows.Add(".051 - Wound Nickel/Steel Hybrid Bass String", "0,000512645");
        circleKTable.Rows.Add(".053 - Wound Nickel/Steel Hybrid Bass String", "0,000551898");
        circleKTable.Rows.Add(".055 - Wound Nickel/Steel Hybrid Bass String", "0,000584407");
        circleKTable.Rows.Add(".057 - Wound Nickel/Steel Hybrid Bass String", "0,000625704");
        circleKTable.Rows.Add(".059 - Wound Nickel/Steel Hybrid Bass String", "0,000679149");
        circleKTable.Rows.Add(".061 - Wound Nickel/Steel Hybrid Bass String", "0,000720293");
        circleKTable.Rows.Add(".063 - Wound Nickel/Steel Hybrid Bass String", "0,000765973");
        circleKTable.Rows.Add(".065 - Wound Nickel/Steel Hybrid Bass String", "0,000821116");
        circleKTable.Rows.Add(".067 - Wound Nickel/Steel Hybrid Bass String", "0,000870707");
        circleKTable.Rows.Add(".070 - Wound Nickel/Steel Hybrid Bass String", "0,000939851");
        circleKTable.Rows.Add(".073 - Wound Nickel/Steel Hybrid Bass String", "0,001021518");
        circleKTable.Rows.Add(".076 - Wound Nickel/Steel Hybrid Bass String", "0,001110192");
        circleKTable.Rows.Add(".079 - Wound Nickel/Steel Hybrid Bass String", "0,001188974");
        circleKTable.Rows.Add(".082 - Wound Nickel/Steel Hybrid Bass String", "0,001293598");
        circleKTable.Rows.Add(".086 - Wound Nickel/Steel Hybrid Bass String", "0,001416131");
        circleKTable.Rows.Add(".090 - Wound Nickel/Steel Hybrid Bass String", "0,001544107");
        circleKTable.Rows.Add(".094 - Wound Nickel/Steel Hybrid Bass String", "0,001677765");
        circleKTable.Rows.Add(".098 - Wound Nickel/Steel Hybrid Bass String", "0,001831487");
        circleKTable.Rows.Add(".102 - Wound Nickel/Steel Hybrid Bass String", "0,001986524");
        circleKTable.Rows.Add(".106 - Wound Nickel/Steel Hybrid Bass String", "0,002127413");
        circleKTable.Rows.Add(".112 - Wound Nickel/Steel Hybrid Bass String", "0,002367064");
        circleKTable.Rows.Add(".118 - Wound Nickel/Steel Hybrid Bass String", "0,002616406");
        circleKTable.Rows.Add(".124 - Wound Nickel/Steel Hybrid Bass String", "0,002880915");
        circleKTable.Rows.Add(".130 - Wound Nickel/Steel Hybrid Bass String", "0,003154996");
        circleKTable.Rows.Add(".136 - Wound Nickel/Steel Hybrid Bass String", "0,003441822");
        circleKTable.Rows.Add(".142 - Wound Nickel/Steel Hybrid Bass String", "0,003741715");
        circleKTable.Rows.Add(".150 - Wound Nickel/Steel Hybrid Bass String", "0,004051506");
        circleKTable.Rows.Add(".158 - Wound Nickel/Steel Hybrid Bass String", "0,004375389");
        circleKTable.Rows.Add(".166 - Wound Nickel/Steel Hybrid Bass String", "0,005078724");
        circleKTable.Rows.Add(".174 - Wound Nickel/Steel Hybrid Bass String", "0,005469937");
        circleKTable.Rows.Add(".182 - Wound Nickel/Steel Hybrid Bass String", "0,006071822");
        circleKTable.Rows.Add(".190 - Wound Nickel/Steel Hybrid Bass String", "0,006605072");
        circleKTable.Rows.Add(".200 - Wound Nickel/Steel Hybrid Bass String", "0,007311717");
        circleKTable.Rows.Add(".210 - Wound Nickel/Steel Hybrid Bass String", "0,008037439");
        circleKTable.Rows.Add(".222 - Wound Nickel/Steel Hybrid Bass String", "0,009091287");
        circleKTable.Rows.Add(".232 - Wound Nickel/Steel Hybrid Bass String", "0,009888443");
        circleKTable.Rows.Add(".244 - Wound Nickel/Steel Hybrid Bass String", "0,010907182");
        circleKTable.Rows.Add(".254 - Wound Nickel/Steel Hybrid Bass String", "0,011787319");

        var closest =
            circleKTable.Select()
                .OrderBy(dr => Math.Abs(Convert.ToDouble(dr["UnitWeight"]) - unitWeight))
                .FirstOrDefault();

        StringGauge = (string)closest["Size"];

        return StringGauge;
    }
    #endregion

}