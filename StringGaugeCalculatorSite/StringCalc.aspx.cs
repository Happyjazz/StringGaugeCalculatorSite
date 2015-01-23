using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StringCalc : System.Web.UI.Page
{
    DataTable _frequenciesTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            populateFrequencyDropdowns();
        }
        
    }

    #region Actions
    protected void buttonCalculate_Click(object sender, EventArgs e)
    {
        float frequency = (float)Convert.ToDouble(txtStringFreq6.Text);
        float tension = (float)Convert.ToDouble(txtTension.Text);
        float scale = (float)Convert.ToDouble(txtScale.Text);

        float unitWeight = CalculateUnitWeight(frequency, tension, scale);

        txtUnitWeight6.Text = Convert.ToString(unitWeight);
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
    }
    #endregion


    #region Private Methods
    //This methods calculates the Unit Weight from the values entered into Frequency, Tension and Scale
    float CalculateUnitWeight(float frequency, float tension, float scale)
    {
        float result = (tension * (float)386.4) / ((2 * scale * frequency) * (2 * scale * frequency));
        return result;
    }

    void populateFrequencyDropdowns()
    {
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
        _frequenciesTable.Rows.Add("261,63 Hz \tC4", "261,63");
        _frequenciesTable.Rows.Add("277,18 Hz \tC#4/Db4 ", "277,18");
        _frequenciesTable.Rows.Add("293,66 Hz \tD4", "293,66");
        _frequenciesTable.Rows.Add("311,13 Hz \tD#4/Eb4 ", "311,13");
        _frequenciesTable.Rows.Add("329,63 Hz \tE4", "329,63");
        _frequenciesTable.Rows.Add("349,23 Hz \tF4", "349,23");
        _frequenciesTable.Rows.Add("369,99 Hz \tF#4/Gb4 ", "369,99");
        _frequenciesTable.Rows.Add("392,00 Hz \tG4", "392");
        _frequenciesTable.Rows.Add("415,30 Hz \tG#4/Ab4 ", "415,3");
        _frequenciesTable.Rows.Add("440,00 Hz \tA4", "440");
        _frequenciesTable.Rows.Add("466,16 Hz \tA#4/Bb4 ", "466,16");
        _frequenciesTable.Rows.Add("493,88 Hz \tB4", "493,88");
        _frequenciesTable.Rows.Add("523,25 Hz \tC5", "523,25");
        _frequenciesTable.Rows.Add("554,37 Hz \tC#5/Db5 ", "554,37");
        _frequenciesTable.Rows.Add("587,33 Hz \tD5", "587,33");
        _frequenciesTable.Rows.Add("622,25 Hz \tD#5/Eb5 ", "622,25");
        _frequenciesTable.Rows.Add("659,25 Hz \tE5", "659,25");
        _frequenciesTable.Rows.Add("698,46 Hz \tF5", "698,46");
        _frequenciesTable.Rows.Add("739,99 Hz \tF#5/Gb5 ", "739,99");
        _frequenciesTable.Rows.Add("783,99 Hz \tG5", "783,99");
        _frequenciesTable.Rows.Add("830,61 Hz \tG#5/Ab5 ", "830,61");
        _frequenciesTable.Rows.Add("880,00 Hz \tA5", "880");
        _frequenciesTable.Rows.Add("932,33 Hz \tA#5/Bb5 ", "932,33");
        _frequenciesTable.Rows.Add("987,77 Hz \tB5", "987,77");
        _frequenciesTable.Rows.Add("1046,5 Hz \tC6", "1046,5");
        _frequenciesTable.Rows.Add("1108,73 Hz \tC#6/Db6 ", "1108,73");
        _frequenciesTable.Rows.Add("1174,66 Hz \tD6", "1174,66");
        _frequenciesTable.Rows.Add("1244,51 Hz \tD#6/Eb6 ", "1244,51");
        _frequenciesTable.Rows.Add("1318,51 Hz \tE6", "1318,51");
        _frequenciesTable.Rows.Add("1396,91 Hz \tF6", "1396,91");
        _frequenciesTable.Rows.Add("1479,98 Hz \tF#6/Gb6 ", "1479,98");
        _frequenciesTable.Rows.Add("1567,98 Hz \tG6", "1567,98");
        _frequenciesTable.Rows.Add("1661,22 Hz \tG#6/Ab6 ", "1661,22");
        _frequenciesTable.Rows.Add("1760,00 Hz \tA6", "1760");
        _frequenciesTable.Rows.Add("1864,66 Hz \tA#6/Bb6 ", "1864,66");
        _frequenciesTable.Rows.Add("1975,53 Hz \tB6", "1975,53");
        _frequenciesTable.Rows.Add("2093,00 Hz \tC7", "2093");
        _frequenciesTable.Rows.Add("2217,46 Hz \tC#7/Db7 ", "2217,46");
        _frequenciesTable.Rows.Add("2349,32 Hz \tD7", "2349,32");
        _frequenciesTable.Rows.Add("2489,02 Hz \tD#7/Eb7 ", "2489,02");
        _frequenciesTable.Rows.Add("2637,02 Hz \tE7", "2637,02");
        _frequenciesTable.Rows.Add("2793,83 Hz \tF7", "2793,83");
        _frequenciesTable.Rows.Add("2959,96 Hz \tF#7/Gb7 ", "2959,96");
        _frequenciesTable.Rows.Add("3135,96 Hz \tG7", "3135,96");
        _frequenciesTable.Rows.Add("3322,44 Hz \tG#7/Ab7 ", "3322,44");
        _frequenciesTable.Rows.Add("3520,00 Hz \tA7", "3520");
        _frequenciesTable.Rows.Add("3729,31 Hz \tA#7/Bb7 ", "3729,31");
        _frequenciesTable.Rows.Add("3951,07 Hz \tB7", "3951,07");
        _frequenciesTable.Rows.Add("4186,01 Hz \tC8", "4186,01");
        _frequenciesTable.Rows.Add("4434,92 Hz \tC#8/Db8 ", "4434,92");
        _frequenciesTable.Rows.Add("4698,63 Hz \tD8", "4698,63");
        _frequenciesTable.Rows.Add("4978,03 Hz \tD#8/Eb8 ", "4978,03");
        _frequenciesTable.Rows.Add("5274,04 Hz \tE8", "5274,04");
        _frequenciesTable.Rows.Add("5587,65 Hz \tF8", "5587,65");
        _frequenciesTable.Rows.Add("5919,91 Hz \tF#8/Gb8 ", "5919,91");
        _frequenciesTable.Rows.Add("6271,93 Hz \tG8", "6271,93");
        _frequenciesTable.Rows.Add("6644,88 Hz \tG#8/Ab8 ", "6644,88");
        _frequenciesTable.Rows.Add("7040,00 Hz \tA8", "7040");
        _frequenciesTable.Rows.Add("7458,62 Hz \tA#8/Bb8 ", "7458,62");
        _frequenciesTable.Rows.Add("7902,13 Hz \tB8", "7902,13");

        ddString6.DataSource = _frequenciesTable;
        ddString6.DataTextField = "Note";
        ddString6.DataValueField = "Frequency";
        ddString6.DataBind();
        ddString6.SelectedValue = "30,87";
        txtStringFreq6.Enabled = false;
        txtStringFreq6.Text = ddString6.SelectedValue;

        ddString5.DataSource = _frequenciesTable;
        ddString5.DataTextField = "Note";
        ddString5.DataValueField = "Frequency";
        ddString5.DataBind();
        ddString5.SelectedValue = "41,2";
        txtStringFreq5.Enabled = false;
        txtStringFreq5.Text = ddString5.SelectedValue;

        ddString4.DataSource = _frequenciesTable;
        ddString4.DataTextField = "Note";
        ddString4.DataValueField = "Frequency";
        ddString4.DataBind();
        ddString4.SelectedValue = "55";
        txtStringFreq4.Enabled = false;
        txtStringFreq4.Text = ddString4.SelectedValue;

        ddString3.DataSource = _frequenciesTable;
        ddString3.DataTextField = "Note";
        ddString3.DataValueField = "Frequency";
        ddString3.DataBind();
        ddString3.SelectedValue = "73,42";
        txtStringFreq3.Enabled = false;
        txtStringFreq3.Text = ddString3.SelectedValue;

        ddString2.DataSource = _frequenciesTable;
        ddString2.DataTextField = "Note";
        ddString2.DataValueField = "Frequency";
        ddString2.DataBind();
        ddString2.SelectedValue = "98";
        txtStringFreq2.Enabled = false;
        txtStringFreq2.Text = ddString2.SelectedValue;

        ddString1.DataSource = _frequenciesTable;
        ddString1.DataTextField = "Note";
        ddString1.DataValueField = "Frequency";
        ddString1.DataBind();
        ddString1.SelectedValue = "130,81";
        txtStringFreq1.Enabled = false;
        txtStringFreq1.Text = ddString1.SelectedValue;
    }

    #endregion
    
    
}