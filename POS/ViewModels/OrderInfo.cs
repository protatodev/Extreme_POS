﻿using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using POS.Models;

namespace POS.ViewModels
{
    public class OrderInfo
    {
        public List<Ticket> AllTickets { get; set; }
        public List<Food> AllFood { get; set; }
        public List<Drink> AllDrink { get; set; }
        public List<User> AllUsers { get; set; }
        public List<Table> AllTables { get; set; }

        public Food FoundFood { get;  set; }
        public Drink FoundDrink { get; set; }
        public User FoundUser { get; set; }
        public Table FoundTable { get; set; }
        public Ticket FoundTicket { get; set; }


        public OrderInfo()
        {
            AllFood = Food.GetAll();
            AllDrink = Drink.GetAll();
            AllUsers = User.GetAll();
            AllTables = Table.GetAll();
            AllTickets = Ticket.GetAll();
         
        }



        // public List<Food> GetFoodOrder()
        //{

        //    MySqlConnection conn = DB.Connection();
        //    conn.Open();
        //    var cmd = conn.CreateCommand() as MySqlCommand;
        //    cmd.CommandText = @"SELECT stylists.* FROM food
        //            JOIN stylists_food ON (food.id = stylists_food.specialty_id)
        //           JOIN stylists ON (stylists_food.stylist_id = stylists.id)
        //           WHERE food.id = @specialtyId;";

        //    cmd.Parameters.AddWithValue("@specialtyId", this.Id);

        //    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        //    List<Stylist> allStylistWithSpec = new List<Stylist> { };

        //    while (rdr.Read())
        //    {

        //        string name = rdr.GetString(1);
        //        int id = rdr.GetInt32(0);

        //        Stylist newStylist = new Stylist(name, id);
        //        allStylistWithSpec.Add(newStylist);
        //    }
        //    conn.Close();
        //    if (conn != null)
        //    {
        //        conn.Dispose();
        //    }
        //    return allStylistWithSpec;
        //}


        public void FindFood(int id)
        {
            FoundFood = Food.Find(id);
        }

        public void FindDrink(int id)
        {
            FoundDrink = Drink.Find(id);
        }

        public void FindUser(int id)
        {
            FoundUser = User.Find(id);
        }

        public void FindTable(int id)
        {
            FoundTable = Table.Find(id);
        }

        public void FindTicketNumber(int tixNum)
        {
            FoundTicket = Ticket.FindTicketNumber(tixNum);
        }


  
    }
}
