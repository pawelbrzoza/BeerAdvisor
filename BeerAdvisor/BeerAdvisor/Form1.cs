using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace BeerAdviser
{
    public partial class Form1 : Form
    {
        List<Beer> allBeers = new List<Beer>();
        List<string> checkedFeatures = new List<string>();
        List<string> otherBeers = new List<string>();
        string selectedBeer;

        private class Beer
        {
            string name;
            List<string> features;

            public Beer(string name, List<string> features)
            {
                this.Name = name;
                this.Features = features;
            }

            public string Name { get => name; set => name = value; }
            public List<string> Features { get => features; set => features = value; }
        }

        public Form1()
        {
            allBeers.Add(new Beer("Lech",          new List<string>(new string[] { "słodkie", "gazowane", "duża piana", "jasne" })));
            allBeers.Add(new Beer("Lech Free",     new List<string>(new string[] { "słodkie", "średniogazowane", "mała piana", "jasne" })));
            allBeers.Add(new Beer("Lech Radler",   new List<string>(new string[] { "słodkie", "średniogazowane", "mała piana", "jasne", "smakowe" })));
            allBeers.Add(new Beer("Tyskie",        new List<string>(new string[] { "gorzkie", "gazowane", "mała piana", "jasne" })));
            allBeers.Add(new Beer("Tyskie Radler", new List<string>(new string[] { "słodkie", "średniogazowane", "mała piana", "jasne", "smakowe" })));
            allBeers.Add(new Beer("Perła",         new List<string>(new string[] { "słodkie", "gazowane", "duża piana", "jasne" })));
            allBeers.Add(new Beer("Gosser",        new List<string>(new string[] { "słodkie", "średniogazowane", "duża piana", "jasne" })));
            allBeers.Add(new Beer("Heineken",      new List<string>(new string[] { "słodkie", "średniogazowane", "duża piana", "jasne" })));
            allBeers.Add(new Beer("Żywiec",        new List<string>(new string[] { "gorzkie", "gazowane", "duża piana", "jasne" })));
            allBeers.Add(new Beer("Żywiec Porter", new List<string>(new string[] { "gorzkie", "gazowane", "duża piana", "ciemne" })));
            allBeers.Add(new Beer("Okocim",        new List<string>(new string[] { "gorzkie", "gazowane", "duża piana", "jasne" })));
            allBeers.Add(new Beer("Okocim Porter", new List<string>(new string[] { "gorzkie", "średniogazowane", "mała piana", "ciemne" })));
            allBeers.Add(new Beer("Carlsberg",     new List<string>(new string[] { "gorzkie", "gazowane", "duża piana", "ciemne" })));
            allBeers.Add(new Beer("Tatra",         new List<string>(new string[] { "gorzkie", "średniogazowane", "mała piana", "jasne", "tanie" })));
            allBeers.Add(new Beer("Harnaś",        new List<string>(new string[] { "gorzkie", "średniogazowane", "mała piana", "jasne", "tanie" })));

            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            checkedFeatures.Clear();
            otherBeers.Clear();

            //load data from comboboxa and checkedlist
            selectedBeer = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            foreach (var item in checkedListBox1.CheckedItems)
                checkedFeatures.Add(item.ToString());

            //checking and adding favourite beers features

            addingSelectedBeerFeatures();

            foreach (var xx in checkedFeatures)
                listBox1.Items.Add(xx);

            checkingInMyTypeBeers();

        }

        private void addingSelectedBeerFeatures()
        {
           
            var myBeer = allBeers.Find(r => r.Name == selectedBeer);

            if(myBeer != null)
            {
                bool state;
                for (int j = 0; j < myBeer.Features.Count; j++)
                {
                    state = false;
                    for (int i = 0; i < checkedFeatures.Count; i++)
                    {
                        if (checkedFeatures[i] == myBeer.Features[j])
                            state = true;
                    }
                    if (state == false)
                        checkedFeatures.Add(myBeer.Features[j]);
                }
            }
        }

        private void checkingInMyTypeBeers()
        {

            // adding beer on list if only one beer features is met

            if(radioButton2.Checked == true)
            {
                bool state;
                for (int i = 0; i < checkedFeatures.Count ; i++)
                {
                    for (int j = 0; j < allBeers.Count ; j++)
                    {
                        state = false;
                        for (int z = 0; z < allBeers[j].Features.Count; z++)
                        {
                            if (checkedFeatures[i] == allBeers[j].Features[z])
                                state = true;
                        }

                        if (state == true && listBox2.FindString(allBeers[j].Name) == -1)
                            listBox2.Items.Add(allBeers[j].Name);
                    }
                }
            }
            else
            {
                // adding beer on list if all bear features are met

                bool exist, allexist;

                for (int j = 0; j < allBeers.Count; j++)
                {
                    allexist = true;
                    for (int i = 0; i < checkedFeatures.Count; i++)
                    {
                        exist = false;
                        for (int z = 0; z < allBeers[j].Features.Count; z++)
                        {
                            if (checkedFeatures[i] == allBeers[j].Features[z])
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (exist == false)
                            allexist = false;
                    }
                    if (allexist == true)
                        listBox2.Items.Add(allBeers[j].Name);
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}