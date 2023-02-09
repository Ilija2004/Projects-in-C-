using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DraftHA
{
    public partial class Form1 : Form
    {
        //Change 1
        static Panel nextPanel;
        static string nextPanelStr = "";
        static string wandName = "";
        static string weaponName = "";
        static string newCharName = "";
        static int hitPoints = 0;
        static int tempCharIndex = -1;

        //8
        static int allCharIndex = -1;
        //9
        static int numOfDeadChar = 0;
        //10
        static Character tempChar;
        //11
        static Character chosenChar;
        //12
        static Character randChar;
        //13
        List<Character> createdChars = new List<Character>();

        //Change 2
        public Form1()
        {
            InitializeComponent();
            Weapon weapon = new Weapon("Sword", 10);
            Wand wand = new Wand("Staff", 20);
            Warrior warrior = new Warrior("Erlan Shen", weapon);
            Mage mage = new Mage("Merlin", wand);
            createdChars.Add(warrior);
            createdChars.Add(mage);
        }

        //Change 3
        private void btnAllChars_Click(object sender, EventArgs e)
        {
            //Clear the previously shown list of characters to display the updated characters list
            lstBxAllChars.Items.Clear();
            foreach (Character character in createdChars)
            {

                lstBxAllChars.Items.Add(character.GetType().Name + ": " + character.name);

            }

        }

        //Change 4
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //The if statement is used as a Validation, to ensure that an actual character has been selected rather than an empty slot in the list box
            if (lstBxAllChars.SelectedItem != null)
            {
                string selectedItem = lstBxAllChars.SelectedItem.ToString();
                string charType = selectedItem.Split(':')[0]; //fetching the first part of the string which is the character's type

                //Depending on the charType the corresponsing image will be displayed in the picture box
                switch (charType)
                {
                    case "Mage":
                        picBxCharList.Image = imageList1.Images[0];
                        break;
                    case "Warrior":
                        picBxCharList.Image = imageList1.Images[1];
                        break;
                }

                //The index of the selected character from the list box is assigned to the tempCharIndex
                //This index should be used to fetch the corresponding character from the characters list since the same index in the list box and the characters list is used
                tempCharIndex = lstBxAllChars.SelectedIndex;
                tempChar = createdChars[tempCharIndex];

                // The following labels should be assigned to the corresponding fields of the tempPlayerCharacter

                lblCharName.Text = tempChar.name;
                lblCharHealth.Text = tempChar.health.ToString();
                lblCharPoints.Text = tempChar.points.ToString();
                lblCharLevel.Text = tempChar.level.ToString();
                lblLoses.Text = tempChar.loses.ToString();
                lblWins.Text = tempChar.wins.ToString();

                if (tempChar.health <= 0)
                {
                    btnCharChoose.Enabled = false;
                }
                else
                {
                    btnCharChoose.Enabled = true;
                }

            }
        }

        //Change 5
        private void btnCharChoose_Click(object sender, EventArgs e)
        {

            chosenChar = createdChars[tempCharIndex];
            allCharIndex = tempCharIndex;
            btnGenRanEnemy.Enabled = true;

            // The following text boxes should be assigned to the corresponding fields of the Player Character object
            txtBxCharNameB.Text = chosenChar.name;
            txtBxCharHealthB.Text = chosenChar.health.ToString();
            txtBxCharPointsB.Text = chosenChar.points.ToString();
            txtBxCharLvlB.Text = chosenChar.level.ToString();
        }

        //Change 6
        private void btnChooseWeapon_Click(object sender, EventArgs e)
        {
            //If the Weapon has been chosen, all the necessary data now has been extracted to create a new Warrior character

            //You need to complete the following comments to actually create this object

            //--> create a new Warrior using newCharName (assigned from the "Character Choice Button" click event)
            //--> create a new Weapon using weaponName and hitPoints
            //--> add the new warrior to the characters list

            Weapon weapon = new Weapon(weaponName, hitPoints);
            Warrior warrior = new Warrior(newCharName, weapon);
            createdChars.Add(warrior);
            //panel has been reset accordingly            
            pnlEquipWarrior.Visible = false;
        }

        //Change 7
        private void btnChooseWand_Click(object sender, EventArgs e)
        {
            //If the Wand has been chosen, all the necessary data now has been extracted to create a new Mage character

            //You need to complete the following comments to actually create this object

            Wand wand = new Wand(weaponName, hitPoints);
            Mage mage = new Mage(newCharName, wand);
            createdChars.Add(mage);


            //panels have been reset accordingly
            pnlEquipWarrior.Visible = false;
            pnlEquipMage.Visible = false;
        }

        //Change 8
        private void btnGenRanEnemy_Click_1(object sender, EventArgs e)
        {


            if (numOfDeadChar < createdChars.Capacity && chosenChar.health > 0)
            {
                btnFight.Enabled = true;
                var rand = new Random();
                int randomIndex = rand.Next(createdChars.Count);
                randChar = createdChars[randomIndex];

                int chosenCharIndex = createdChars.IndexOf(chosenChar);

                while (randomIndex == chosenCharIndex || randChar.health <= 0)
                {
                    randChar = createdChars[randomIndex];
                    return;
                }
                txtBxEnemyNameB.Text = randChar.name;
                txtBxEnemyHealthB.Text = randChar.health.ToString();
                txtBxEnemyPointsB.Text = randChar.points.ToString();
                txtBxEnemyLvlB.Text = randChar.level.ToString();
            }

        }

        

        //Change 9
        private void btnFight_Click(object sender, EventArgs e)
        {
            var rand = new Random();
            int playerRange = chosenChar.level * 20;
            int enemyRange = randChar.level * 20;

            int total = enemyRange + playerRange;
            int RandNum = rand.Next(1, total);

            if (RandNum <= playerRange)
            {
             
                chosenChar.Battle(chosenChar , true);
                randChar.Battle(randChar , false);

            }
            else if(RandNum >= playerRange )
            {
                chosenChar.Battle(chosenChar, false);
                randChar.Battle(randChar, true);

            }
            if (chosenChar.health <= 0 || randChar.health <= 0)
            {
                
                btnFight.Enabled = false;
                numOfDeadChar++;


            }

            txtBxCharNameB.Text = chosenChar.name;
            txtBxCharHealthB.Text = chosenChar.health.ToString();
            txtBxCharPointsB.Text = chosenChar.points.ToString();
            txtBxCharLvlB.Text = chosenChar.level.ToString();

            txtBxEnemyNameB.Text = randChar.name;
            txtBxEnemyHealthB.Text = randChar.health.ToString();
            txtBxEnemyPointsB.Text = randChar.points.ToString();
            txtBxEnemyLvlB.Text = randChar.level.ToString();
        }
        




        //No need to update

        private void rdBtnMage_CheckedChanged(object sender, EventArgs e)
        {
            //If the mage radio button is checked then
            //the picture box should show the first image in the imageList1 since it's a Mage image
            picBxAddChar.Image = imageList1.Images[0];
            
            //next panel to be shown is the panel having the GUI to choose a wand for the mage
            nextPanel = pnlEquipMage;
            nextPanelStr = "pnlEquipMage";
        }

        private void rdBtnWarrior_CheckedChanged(object sender, EventArgs e)
        {
            //If the warrior radio button is checked then
            //the picture box should show the third image in the imageList1 since it's a Warrior image
            picBxAddChar.Image = imageList1.Images[1];

            //next panel to be shown is the panel having the GUI to choose a weapon for the warrior
            nextPanel = pnlEquipWarrior;
            nextPanelStr = "pnlEquipWarrior";
        }


        private void rdBtnDragon_CheckedChanged(object sender, EventArgs e)
        {
            //If the dragon claw radio button is checked then
            //the picture box should show the first image in the imgListMageEquip since it's a Dragon Claw image
            picBoxMageEquip.Image = imgListMageEquip.Images[0];

            //Set the variables with the details for Dragon Claw to be used when the wand is then created
            wandName = "Dragon Claw";
            hitPoints = 15;
        }

        private void rdBtnUltimate_CheckedChanged(object sender, EventArgs e)
        {
            //If the Ultimate energy radio button is checked then
            //the picture box should show the third image in the imgListMageEquip since it's an Ultimate Energy image
            picBoxMageEquip.Image = imgListMageEquip.Images[2];

            //Set the variables with the details for Ultimate Energy to be used when the wand is then created
            wandName = "Ultimate Energy";
            hitPoints = 25;
        }

        private void rdBtnMother_CheckedChanged(object sender, EventArgs e)
        {
            //If the Mother Nature radio button is checked then
            //the picture box should show the second image in the imgListMageEquip since it's a Mother Nature image
            picBoxMageEquip.Image = imgListMageEquip.Images[1];

            //Set the variables with the details for Mother Nature to be used when the wand is then created
            wandName = "Mother Nature";
            hitPoints = 20;
        }

        private void rdBtnAxe_CheckedChanged_1(object sender, EventArgs e)
        {
            //If the Battle Axe radio button is checked then
            //the picture box should show the first image in the imgListMageEquip since it's a Battle Axe image
            picBoxWeapons.Image = weaponImageList.Images[0];

            //Set the variables with the details for Battle Axe to be used when the weapon is then created
            weaponName = "Battle Axe";
            hitPoints = 10;
        }

        private void rdBtnHammer_CheckedChanged_1(object sender, EventArgs e)
        {
            //If the War Hammer radio button is checked then
            //the picture box should show the second image in the imgListMageEquip since it's a War Hammer image
            picBoxWeapons.Image = weaponImageList.Images[1];

            //Set the variables with the details for War Hammer to be used when the weapon is then created
            weaponName = "War Hammer";
            hitPoints = 15;
        }

        private void rdBtnKatana_CheckedChanged_1(object sender, EventArgs e)
        {
            //If the Katana radio button is checked then
            //the picture box should show the third image in the imgListMageEquip since it's a Katana image
            picBoxWeapons.Image = weaponImageList.Images[2];

            //Set the variables with the details for Katana to be used when the weapon is then created
            weaponName = "Katana";
            hitPoints = 20;
        }

        private void btnCharChoice_Click(object sender, EventArgs e)
        {
            //newCharName is assigned with the text inserted in the text box used for the user to write the new character's name
            newCharName = txtBxCharName.Text;
            txtBxCharName.Text = ""; //clear the text box to be ready for any new characters to be created

            //The below code is set to change the panel viewing to allow the user to create more characters
            if (nextPanelStr == "pnlEquipWarrior")
                pnlEquipWarrior.Visible = true;
            else if (nextPanelStr == "pnlEquipMage")
            {
                pnlEquipWarrior.Visible = true;
                pnlEquipMage.Visible = true;
            }

        }

        private void txtBxEnemyNameB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
