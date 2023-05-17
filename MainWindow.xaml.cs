using CatBDWPF.Serves;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatBDWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               
                FamilyComboB.ItemsSource = db.Families.ToList();
                db.Database.Connection.Close();
            }
        }

        private void AddFamilyBTN_Click(object sender, RoutedEventArgs e)
        {
            FamilyNameTB.Visibility = Visibility.Visible;
            CreateFamilyBTN.Visibility = Visibility.Visible;
            OtmenaCreateBTN.Visibility = Visibility.Visible;
            AddFamilyBTN.Visibility = Visibility.Hidden;
            DeleteFamilyBTN.Visibility = Visibility.Hidden;
            ViewInfoBTN.Visibility= Visibility.Hidden; 
            RedactionBTN.Visibility= Visibility.Hidden;
            foreach (TextBox tb in StackPInfoSP.Children)
            {
                tb.Text = "0";
                tb.IsReadOnly = false;
            }
            foreach (TextBox tb in StackPCharacter.Children)
            {
                tb.Text = "0";
                tb.IsReadOnly = false;
            }

        }

        private void OtmenaCreateBTN_Click(object sender, RoutedEventArgs e)
        {
            FamilyNameTB.Visibility = Visibility.Hidden;
            CreateFamilyBTN.Visibility = Visibility.Hidden;
            OtmenaCreateBTN.Visibility = Visibility.Hidden;
            AddFamilyBTN.Visibility = Visibility.Visible;
            DeleteFamilyBTN.Visibility = Visibility.Visible;
            ViewInfoBTN.Visibility = Visibility.Visible;
            RedactionBTN.Visibility = Visibility.Visible;
            foreach (TextBox tb in StackPInfoSP.Children)
            {
                tb.Text = "";
                tb.IsReadOnly = true;
            }
            foreach (TextBox tb in StackPCharacter.Children)
            {
                tb.Text = "";
                tb.IsReadOnly = true;
            }
            FamilyNameTB.Text = "Введите название породы";
        }

        private void CreateFamilyBTN_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                ApplicationDbServes serves = new ApplicationDbServes();
                serves.AddFamily(
                    //Информация
                    FamilyNameTB.Text,
                    countryTB.Text,
                    lifeExpectancyTB.Text,
                    sizeTB.Text,
                    Convert.ToDouble(weightTB.Text),
                    coatTypeTB.Text,
                    colorTB.Text,
                    lifestyleTB.Text,
                    groupTB.Text,
                    priceTB.Text,
                    //Характеристики
                    Convert.ToInt32(adaptabilitiTB.Text),
                    Convert.ToInt32(attachmentTofamilyTB.Text),
                    Convert.ToInt32(gameActivityTB.Text),
                    Convert.ToInt32(intelligenceTB.Text),
                    Convert.ToInt32(generalHealthTB.Text),
                    Convert.ToInt32(hairLossTB.Text),
                    Convert.ToInt32(friendlinessForChildreTB.Text),
                    Convert.ToInt32(friendlyToDogsTB.Text),
                    Convert.ToInt32(loveForMeowTB.Text)
                    );
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                FamilyComboB.ItemsSource = db.Families.ToList();
                db.Database.Connection.Close();
            }
        }

        private void DeleteFamilyBTN_Click(object sender, RoutedEventArgs e)
        {
            ApplicationDbServes serves = new ApplicationDbServes();
            if (FamilyComboB.SelectedItem != null)
            {
                serves.DeleteFamily(FamilyComboB.SelectedItem.ToString());
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    FamilyComboB.ItemsSource = db.Families.ToList();
                    db.Database.Connection.Close();
                }
                foreach (TextBox tb in StackPInfoSP.Children)
                {
                    tb.Text = "";

                }
                foreach (TextBox tb in StackPCharacter.Children)
                {
                    tb.Text = "";

                }
            }
        }

        private void RedactionBTN_Click(object sender, RoutedEventArgs e)
        {
            EnterRedactionBTN.Visibility = Visibility.Visible;
            OtmenaRedactionBTN.Visibility = Visibility.Visible;
            AddFamilyBTN.Visibility = Visibility.Hidden;
            DeleteFamilyBTN.Visibility = Visibility.Hidden;
            ViewInfoBTN.Visibility = Visibility.Hidden;
            RedactionBTN.Visibility = Visibility.Hidden;
            foreach (TextBox tb in StackPInfoSP.Children)
            {
                
                tb.IsReadOnly = false;
            }
            foreach (TextBox tb in StackPCharacter.Children)
            {
                
                tb.IsReadOnly = false;
            }
            MessageBox.Show("Внесите изменения в таблицу");

        }

        private void EnterRedactionBTN_Click(object sender, RoutedEventArgs e)
        {
            EnterRedactionBTN.Visibility = Visibility.Hidden;
            OtmenaRedactionBTN.Visibility = Visibility.Hidden;
            AddFamilyBTN.Visibility = Visibility.Visible;
            DeleteFamilyBTN.Visibility = Visibility.Visible;
            ViewInfoBTN.Visibility = Visibility.Visible;
            RedactionBTN.Visibility = Visibility.Visible;
            try
            {
                ApplicationDbServes serves = new ApplicationDbServes();
                serves.RedactionFamily(
                    //Информация
                    FamilyComboB.SelectedItem.ToString(),
                    countryTB.Text,
                    lifeExpectancyTB.Text,
                    sizeTB.Text,
                    Convert.ToDouble(weightTB.Text),
                    coatTypeTB.Text,
                    colorTB.Text,
                    lifestyleTB.Text,
                    groupTB.Text,
                    priceTB.Text,
                    //Характеристики
                    Convert.ToInt32(adaptabilitiTB.Text),
                    Convert.ToInt32(attachmentTofamilyTB.Text),
                    Convert.ToInt32(gameActivityTB.Text),
                    Convert.ToInt32(intelligenceTB.Text),
                    Convert.ToInt32(generalHealthTB.Text),
                    Convert.ToInt32(hairLossTB.Text),
                    Convert.ToInt32(friendlinessForChildreTB.Text),
                    Convert.ToInt32(friendlyToDogsTB.Text),
                    Convert.ToInt32(loveForMeowTB.Text)
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (TextBox tb in StackPInfoSP.Children)
            {
                tb.IsReadOnly = true;
            }
            foreach (TextBox tb in StackPCharacter.Children)
            {
                tb.IsReadOnly = true;
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                FamilyComboB.ItemsSource = db.Families.ToList();
                db.Database.Connection.Close();
            }
        }

        private void FamilyComboB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) { 
                ApplicationDbServes Serves = new ApplicationDbServes();
                if (FamilyComboB.SelectedItem != null)
                {
                    Family fy = Serves.SeeFaSelect(FamilyComboB.SelectedItem.ToString());

                    if (fy != null)
                    {
                        Character cr = db.Characters.FirstOrDefault(c => c.famyly.Id == fy.Id);
                        BreedInformation bi = db.BreedInformation.FirstOrDefault(b => b.famyly.Id == fy.Id);
                        adaptabilitiTB.Text = cr.Adaptabiliti.ToString();
                        attachmentTofamilyTB.Text = cr.AttachmentTofamily.ToString();
                        intelligenceTB.Text = cr.Intelligence.ToString();
                        gameActivityTB.Text = cr.GameActivity.ToString();
                        loveForMeowTB.Text = cr.LoveForMeow.ToString();
                        generalHealthTB.Text = cr.GeneralHealth.ToString();
                        hairLossTB.Text = cr.HairLoss.ToString();
                        friendlyToDogsTB.Text = cr.FriendlyToDogs.ToString();
                        friendlinessForChildreTB.Text = cr.FriendlinessForChildren.ToString();

                        countryTB.Text = bi.CountryOfOrigin.ToString();
                        lifeExpectancyTB.Text = bi.LifeExpectancy.ToString();
                        sizeTB.Text = bi.Size.ToString();
                        weightTB.Text = bi.Weight_kg.ToString();
                        coatTypeTB.Text = bi.CoatType.ToString();
                        colorTB.Text = bi.Color.ToString();
                        lifestyleTB.Text = bi.Lifestyle.ToString();
                        groupTB.Text = bi.Group.ToString();
                        priceTB.Text = bi.Price.ToString();
                    }
                    db.Database.Connection.Close();
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
