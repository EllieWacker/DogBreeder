using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using LogicLayer;
using DataDomain;
using System.Text.RegularExpressions;

namespace WpfPresentation
{
    /// <summary>
    /// Interaction logic for frmPuppyDetail.xaml
    /// </summary>
    public partial class frmPuppyDetail : Window
    {
        private List<Puppy> _puppies = new List<Puppy>();
        private IPuppyManager _puppyManager;
        private string _litterID;
        private int _number;
        private UserVM _userRole;
        public frmPuppyDetail(string litterID, int number, UserVM user)
        {
            this._litterID = litterID;
            this._number = number;
            this._userRole = user;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var puppyManager = new PuppyManager();
            var medicalRecordManager = new MedicalRecordManager();
            _puppies = puppyManager.SelectPuppiesByLitterID(_litterID);
            Puppy puppy = _puppies[_number];
            MedicalRecord medRecord = medicalRecordManager.SelectMedicalRecordByMedicalRecordID(puppy.MedicalRecordID);

            string adopted = "";

            if (puppy.Adopted == true)
            {
                adopted = "Sold";
            }
            else if (puppy.Adopted == false)
            {
                adopted = "Available";
            }

            lblPupAvail.Content = "Availability: " + adopted;
            lblPupBreed.Content = puppy.BreedID;
            lblPupMicro.Content = "Microchip: " + puppy.Microchip;
            lblPupPrice.Content = "Price: $" + puppy.Price;
            lblPupTreatment.Content = "Treatments: " + medRecord.Treatment;
            lblPupWeight.Content = "Weight: " + medRecord.Weight + " lb";

            Uri pupImageUri = new Uri("Photos/" + puppy.Image, UriKind.Relative);

            BitmapImage pupImg = new BitmapImage();
            pupImg.BeginInit();
            pupImg.UriSource = pupImageUri;
            pupImg.CacheOption = BitmapCacheOption.OnLoad;
            pupImg.EndInit();
            imgPup.Source = pupImg;

            if (_userRole.Roles.Contains("Adopter"))
            {
                btnPupAdopt.Visibility = Visibility.Visible;
            }
            else
            {
                btnPupAdopt.Visibility = Visibility.Hidden;
            }


            if (puppy.Adopted == true)
            {
                adopted = "Sold";
                btnPupAdopt.Visibility = Visibility.Hidden;
            }
            else if (puppy.Adopted == false)
            {
                adopted = "Available";
            }



        }

        private void btnPupAdopt_Click(object sender, RoutedEventArgs e)
        {
            var puppyManager = new PuppyManager();
            _puppies = puppyManager.SelectPuppiesByLitterID(_litterID);
            Puppy puppy = _puppies[_number];
            var adoptionManager = new AdoptionManager();
            var applicationManager = new ApplicationManager();
            List<Adoption> adoptions = adoptionManager.GetAllAdoptions();
            DataDomain.Application application = applicationManager.SelectApplicationByUserID(_userRole.UserID);
            try
            {

                foreach (var adoption in adoptions)
                {
                    if (adoption.ApplicationID == application.ApplicationID)
                    {
                        MessageBox.Show("You have already adopted a puppy! Send us an email at DoodleDogs@gmail.com to make a downpayment for another.");
                        this.Close();
                        return;
                    }
                }
                if (adoptionManager.InsertAdoption(application.ApplicationID, puppy.PuppyID, _userRole.UserID, "In Progress") == adoptions.Count + 1000000)
                {
                    MessageBox.Show("Puppy adopted!");
                    this.Close();
                    puppyManager.UpdatePuppy(puppy.PuppyID, false, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                this.Close();
            }

        }
    }
}
