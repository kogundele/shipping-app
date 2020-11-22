using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections;

namespace ShippingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Alabama, Florida, Georgia, Kentucky, Mississippi, North Carolina, South Carolina, Tennessee, West Virginia or Virginia
        List<string> listStates = new List<string>() {"AL", "FL", "GA", "KY", "MS", "NC", "SC", "TN", "WV", "VA"};
        List<Shippment> shippmentsList = new List<Shippment>();
        public DateTime new_shippment_arrival_date;
        public int new_shippment_package_id;
        public int cur_pos;

        public MainWindow()
        {
            InitializeComponent();
            btn_add.IsEnabled = false;
            btn_scan.IsEnabled = true;
            btn_back.IsEnabled = false;
            btn_edit.IsEnabled = false;
            btn_remove.IsEnabled = false;
            btn_next.IsEnabled = false;
            combox_1_states.ItemsSource = listStates;
            combox_2_states.ItemsSource = listStates;
            txt_arrival_date.IsEnabled = false;
            txt_package_id.IsEnabled = false;
        }


        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void btn_click_back(object sender, RoutedEventArgs e)
        {
            prevShippment();
        }

        private void btn_click_scan(object sender, RoutedEventArgs e)
        {
            clearForm();
            // generate shippment date
            new_shippment_arrival_date = DateTime.Now;
            txt_arrival_date.Text = new_shippment_arrival_date.ToString("MM-dd-yyyy HH:mm:ss");
            // generate package id
            var generator = new Random();
            new_shippment_package_id = generator.Next(100000, 999999);
            txt_package_id.Text = (new_shippment_package_id).ToString();
            // btn controls
            btn_scan.IsEnabled = false;
            btn_add.IsEnabled = true;
            btn_remove.IsEnabled = false;
            btn_edit.IsEnabled = false;
            btn_back.IsEnabled = false;
            btn_next.IsEnabled = false;
        }

        private void btn_click_add(object sender, RoutedEventArgs e)
        {
            lbl_msg.Content = "";
            try
            {
                string address = validateTxtInput(txt_address.Text, lbl_address.Content.ToString());
                string city = validateTxtInput(txt_city.Text, lbl_city.Content.ToString());
                string state = validateCombobox(combox_1_states.SelectedIndex, combox_1_states.SelectionBoxItem.ToString(), lbl_city.Content.ToString());
                string zip = validateTxtInput(txt_zip.Text, lbl_zip.Content.ToString());

                Shippment shippment = new Shippment(new_shippment_arrival_date, new_shippment_package_id, address, city, state, zip);
                shippmentsList.Add(shippment);
                btn_add.IsEnabled = false;
                btn_scan.IsEnabled = true;
                if (shippmentsList.Count >= 1)
                {
                    btn_back.IsEnabled = true;
                    btn_next.IsEnabled = true;
                }
                btn_remove.IsEnabled = true;
                btn_edit.IsEnabled = true;
                
                cur_pos = shippmentsList.Count - 1;

                lbl_msg.Content = "Shippmment has been added to list";
            } catch (Exception ex)
            {
                lbl_msg.Content = ex.Message;
            }
        }

        public string validateTxtInput(string input, string lbl)
        {
            if (input == "")
            {
                throw new System.ArgumentException(lbl+" cannot be empty");
            }
            return input;
        }

        public string validateCombobox(int index, string value, string lbl)
        {
            if (index == -1)
            {
                throw new System.ArgumentException(lbl + " was not selected");
            }
            return value;
        }

        public void clearForm()
        {
            txt_arrival_date.Clear();
            txt_package_id.Clear();
            txt_address.Clear();
            txt_city.Clear();
            combox_1_states.SelectedIndex = -1;
            txt_zip.Clear();
            lbl_msg.Content = "";
        }

        private void btn_click_remove(object sender, RoutedEventArgs e)
        {
            lbl_msg.Content = "";
            if (shippmentsList.Count > 0)
            {
                try
                {
                    bool next = false;
                    shippmentsList.RemoveAt(cur_pos);
                    if ((cur_pos + 1 <= shippmentsList.Count - 1) || (cur_pos == 0 && shippmentsList.Count == 1))
                    {
                        next = true;
                        nextShippment();
                    }
                    else if (cur_pos - 1 >= 0 && next == false)
                    {
                        prevShippment();
                    }
                    else
                    {
                        clearForm();
                    }
                    lbl_msg.Content = "Shippmment has been removed";
                } catch (Exception ex)
                {
                    lbl_msg.Content = "Something went wrong, shippment could not be deleted";
                }
                
            }
        }

        private void btn_click_edit(object sender, RoutedEventArgs e)
        {
            lbl_msg.Content = "";
            if (cur_pos >=  0)
            {
                try
                {
                    Shippment shippment = shippmentsList[cur_pos];
                    shippment.Address = validateTxtInput(txt_address.Text, lbl_address.Content.ToString());
                    shippment.City = validateTxtInput(txt_city.Text, lbl_city.Content.ToString());
                    shippment.State = validateCombobox(combox_1_states.SelectedIndex, combox_1_states.SelectionBoxItem.ToString(), lbl_city.Content.ToString());
                    shippment.Zip = validateTxtInput(txt_zip.Text, lbl_zip.Content.ToString());

                    lbl_msg.Content = "Shippmment has Edited";

                } catch (Exception ex)
                {
                    lbl_msg.Content = ex.Message;
                }
            }
        }

        public void nextShippment()
        {
            if (shippmentsList.Count > 0)
            {
                if (cur_pos < shippmentsList.Count - 1)
                {
                    cur_pos = cur_pos + 1;
                }
                Shippment shippment = shippmentsList[cur_pos];
                txt_arrival_date.Text = (shippment.ArrivedAt).ToString("MM-dd-yyyy HH:mm:ss");
                txt_package_id.Text = (shippment.PackageId).ToString();
                txt_address.Text = shippment.Address;
                txt_city.Text = shippment.City;
                combox_1_states.SelectedValue = shippment.State;
                txt_zip.Text = shippment.Zip;
            }
        }

        public void prevShippment()
        {
            if (shippmentsList.Count > 0)
            {
                if (cur_pos > 0)
                {
                    cur_pos = cur_pos - 1;
                }
                Shippment shippment = shippmentsList[cur_pos];
                txt_arrival_date.Text = (shippment.ArrivedAt).ToString("MM-dd-yyyy HH:mm:ss");
                txt_package_id.Text = (shippment.PackageId).ToString();
                txt_address.Text = shippment.Address;
                txt_city.Text = shippment.City;
                combox_1_states.SelectedValue = shippment.State;
                txt_zip.Text = shippment.Zip;
            }
        }

        private void btn_click_next(object sender, RoutedEventArgs e)
        {
            nextShippment();
        }

        private void FilterStateIndexChanged(object sender, EventArgs e)
        {
            list_box_filtered_results.Items.Clear();
            foreach (Shippment shippment in shippmentsList)
            {
                if (combox_2_states.SelectionBoxItem.ToString() == shippment.State)
                {
                    list_box_filtered_results.Items.Add(shippment.PackageId);
                }
            }
        }
    }
}
