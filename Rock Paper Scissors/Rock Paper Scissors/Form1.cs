using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors
{
  public partial class Form1 : Form
  {
    private int playerScore = 0;
    private int pcScore = 0;

    private enum WINNER_OPTIONS
    {
      NONE = 0,
      PLAYER,
      PC
    }
    private enum RPC
    {
      ROCK = 1,
      PAPER,
      SCISSORS
    }
    public Form1()
    {
      InitializeComponent();
    }

    private int pc_rpc_selection()
    {
      Random randInt = new Random();
      return randInt.Next(1, 4);
    }

    private WINNER_OPTIONS get_game_winner(int playerSelection, int pcSelection)
    {
      //equals
      if (playerSelection == pcSelection)
        return WINNER_OPTIONS.NONE;

      if (((RPC)playerSelection == RPC.ROCK && (RPC)pcSelection == RPC.SCISSORS) || 
          ((RPC)playerSelection == RPC.PAPER && (RPC)pcSelection == RPC.ROCK) ||
          ((RPC)playerSelection == RPC.SCISSORS && (RPC)pcSelection == RPC.PAPER))
      {
        return WINNER_OPTIONS.PLAYER;
      }
      else
      {
        return WINNER_OPTIONS.PC;
      }
    }

    private void update_data(WINNER_OPTIONS gameWinner)
    {
      if (gameWinner == WINNER_OPTIONS.NONE)
      {
        label11.Text = "Tie";
      }
      else if (gameWinner == WINNER_OPTIONS.PLAYER)
      {
        playerScore += 1;
        label6.Text = Convert.ToString(playerScore);
        label11.Text = "Player";
      }
      else
      {
        pcScore += 1;
        label8.Text = Convert.ToString(pcScore);
        label11.Text = "PC";
      }
    }

    private void update_pc_selection_data(int pcSelection)
    {
      switch ((RPC)pcSelection)
      {
        case RPC.ROCK:
          label9.Text = "ROCK";
          break;
        case RPC.PAPER:
          label9.Text = "PAPER";
          break;
        case RPC.SCISSORS:
          label9.Text = "SCISSORS";
          break;
        default:
          break;
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void button4_Click(object sender, EventArgs e)
    {
      label6.Text = "";
      label8.Text = "";
      label9.Text = "";
      label11.Text = "";
      label6.Text = "0";
      label8.Text = "0";
      playerScore = 0;
      pcScore = 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var buttonNumber = Regex.Match(button1.Name, @"\d+").Value;
      int pcSelection = pc_rpc_selection();
      update_pc_selection_data(pcSelection);

      WINNER_OPTIONS gameWinner = get_game_winner(Convert.ToInt32(buttonNumber), pcSelection);
      update_data(gameWinner);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      var buttonNumber = Regex.Match(button1.Name, @"\d+").Value;
      int pcSelection = pc_rpc_selection();
      update_pc_selection_data(pcSelection);

      WINNER_OPTIONS gameWinner = get_game_winner(Convert.ToInt32(buttonNumber), pcSelection);
      update_data(gameWinner);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      var buttonNumber = Regex.Match(button1.Name, @"\d+").Value;
      int pcSelection = pc_rpc_selection();
      update_pc_selection_data(pcSelection);

      WINNER_OPTIONS gameWinner = get_game_winner(Convert.ToInt32(buttonNumber), pcSelection);
      update_data(gameWinner);
    }
  }
}
