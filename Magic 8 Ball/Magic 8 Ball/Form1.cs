using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magic_8_Ball
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    //private void Form1_Load(object sender, EventArgs e)
    //{

    //}

    private void button1_Click(object sender, EventArgs e)
    {
     if(textBoxQuestion.Text == "")
      {
        label5.Text = "Please insert your question...";
        return;
      }
      Array values = Enum.GetValues(typeof(Answers));
      Random random = new Random();
      Answers randomAnswer = (Answers)values.GetValue(random.Next(values.Length));

      label4.Text = randomAnswer.ToDescriptionString();
      label5.Text = "";
    }


    //private void label4_Click(object sender, EventArgs e)
    //{

    //}

    private void button2_Click(object sender, EventArgs e)
    {
      textBoxQuestion.Text = "";
      textBoxQuestion.PlaceholderText = "Question...";
    }

    private void button4_Click(object sender, EventArgs e)
    {
      DialogResult dr = MessageBox.Show("Sure you wanna quit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (dr == DialogResult.Yes)
      {
        this.Close();
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      textBoxQuestion.Text = "";
      textBoxQuestion.PlaceholderText = "Question...";
      label4.Text = "";
      label5.Text = "";
    }

    //private void textBoxQuestion_TextChanged(object sender, EventArgs e)
    //{

    //}

    //private void textBoxQuestion_TextChanged(object sender, EventArgs e)
    //{

    //}
  }

  public enum Answers
  {
    [Description("As I see it, yes.")]
    A1 = 1,
    [Description("Ask again later.")]
    A2 = 2,
    [Description("Better not tell you now.")]
    A3 = 3,
    [Description("Cannot predict now.")]
    A4 = 4,
    [Description("Concentrate and ask again.")]
    A5 = 5,
    [Description("Don’t count on it.")]
    A6 = 6,
    [Description("It is certain.")]
    A7 = 7,
    [Description("It is decidedly so.")]
    A8 = 8,
    [Description("Most likely.")]
    A9 = 9,
    [Description("My reply is no.")]
    A10 = 10,
    [Description("My sources say no.")]
    A11 = 11,
    [Description("Outlook not so good.")]
    A12 = 12,
    [Description("Outlook good.")]
    A13 = 13,
    [Description("Reply hazy, try again.")]
    A14 = 14,
    [Description("Signs point to yes.")]
    A15 = 15,
    [Description("Very doubtful.")]
    A16 = 16,
    [Description("Without a doubt.")]
    A17 = 17,
    [Description("Yes.")]
    A18 = 18,
    [Description("Yes – definitely.")]
    A19 = 19,
    [Description("You may rely on it.")]
    A20 = 20
  }

  public static class MyEnumExtensions
  {
    public static string ToDescriptionString(this Answers val)
    {
      DescriptionAttribute[] attributes = (DescriptionAttribute[])val
         .GetType()
         .GetField(val.ToString())
         .GetCustomAttributes(typeof(DescriptionAttribute), false);
      return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
  }

}

