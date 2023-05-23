﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            String insSql = "INSERT INTO students(name, age, groupName) VALUES (@name, @age, @groupName)";
            MySqlCommand insConn = new MySqlCommand(insSql, conn);
            insConn.Parameters.AddWithValue("@name", textBox1.Text.Trim());
            insConn.Parameters.AddWithValue("@age", numericUpDown1.Value);
            insConn.Parameters.AddWithValue("@groupName", textBox2.Text.Trim());
            insConn.Prepare();
            insConn.ExecuteNonQuery();
            conn.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String connStr = "Server=localhost;User ID=exem_pk31;Password=123456;Database=exam_pk31";
            conn = new MySqlConnection(connStr);
            conn.Open();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            String sqlSel = "SELECT name, age, groupName FROM students";
            MySqlCommand sqlComm = new MySqlCommand(sqlSel, conn);
            MySqlDataReader sqlDataReader = sqlComm.ExecuteReader();
            while (sqlDataReader.Read())
            {
                listBox1.Items.Add(sqlDataReader.GetString(0) + "" + sqlDataReader.GetInt32(1) + "" + sqlDataReader.GetString(2));
            }
            conn.Close();
        }
    }
}