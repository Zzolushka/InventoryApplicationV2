using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainTable : ContentPage
	{
        public ListView ListView;
        public int entry;
        

        public ObservableCollection<MyItem> MyItems{ get; set; }
        public List<Phone> Phones { get; set; }
        public MainTable()
        {
            InitializeComponent();
            Phones = new List<Phone>
            {
                new Phone {Title="Galaxy S8", Company="Samsung", Price=48000 },
                new Phone {Title="Huawei P10", Company="Huawei", Price=35000 },
                new Phone {Title="HTC U Ultra", Company="HTC", Price=42000 },
                new Phone {Title="iPhone 7", Company="Apple", Price=52000 }
            };
            

            MyItems = new ObservableCollection<MyItem>();
            MyItems.Add(new MyItem() { Switch = true, Addend1 = 1, Addend2 = 2 });
            MyItems.Add(new MyItem() { Switch = false, Addend1 = 1, Addend2 = 2 });
            MyItems.Add(new MyItem() { Switch = true, Addend1 = 2, Addend2 = 3 });
            MyItems.Add(new MyItem() { Switch = false, Addend1 = 2, Addend2 = 3 });


            ListView = new ListView();

           

            
            

            this.BindingContext = this;
        }

        public async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Phone selectedPhone = e.Item as Phone;
            if (selectedPhone != null)
                await DisplayAlert("Выбранная модель", $"{selectedPhone.Company} - {selectedPhone.Title}", "OK");
        }

        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }

        
        public class MyItem : INotifyPropertyChanged
        {
            bool _switch = false;
            public bool Switch
            {
                get
                {
                    return _switch;
                }
                set
                {
                    if (_switch != value)
                    {
                        _switch = value;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Switch"));
                    }
                }

            }
            public int Addend1 { get; set; }
            public int Addend2 { get; set; }
            public int Result
            {
                get
                {
                    return Addend1 + Addend2;
                }
            }
            public string Summary
            {
                get
                {
                    return Addend1 + " + " + Addend2 + " = " + Result;
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }

        public class AlternateColorDataTemplateSelector : DataTemplateSelector
        {
            public DataTemplate EvenTemplate { get; set; }
            public DataTemplate UnevenTemplate { get; set; }

            protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
            {
                // TODO: Maybe some more error handling here
                return ((List<string>)((ListView)container).ItemsSource).IndexOf(item as string) % 2 == 0 ? EvenTemplate : UnevenTemplate;
            }
        }

        private bool isRowEven;
        private bool isHideColumn;

        private void Cell_OnAppearing(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (this.isRowEven)
            {
                
                if (viewCell.View != null)
                {
                   
                 //   viewCell.View.BackgroundColor = Color.Gray;
                    var label = (Label)viewCell.FindByName("column");
                    var label2 = (Label)viewCell.FindByName("column1");
                    var label3 = (Label)viewCell.FindByName("column2");
                    var label4 = (Label)viewCell.FindByName("column3");

                    ChangeLabelColorToOther(label, Color.Gray);
                    ChangeLabelColorToOther(label2, Color.Gray);
                    ChangeLabelColorToOther(label3, Color.Gray);
                    ChangeLabelColorToOther(label4, Color.Gray);

             

                    //label4.IsVisible = false;
                }
                
            }

            if(this.isHideColumn)
            {
                var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");
            
                gridcolumn.Width = 0;
            }
            else
            {

            }

            this.isRowEven = !this.isRowEven;
        }

        private void ChangeLabelColorToOther(Label label,Color color)
        {
            label.BackgroundColor = color;
        }

        private void HideAndShowColumn(object sender,EventArgs e)
        {
            
            listViewm.BeginRefresh();
            
            listViewm.EndRefresh();

            entry = 0;

           

           

            IEnumerable<PropertyInfo> pInfos = (listViewm as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            if (templatedItems != null)
            {
                var cells = templatedItems.GetValue(listViewm);
                Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell> listCell = cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>;
                for (int i = 0; i < listCell.Count; i++)
                {
                    var viewCell = (ViewCell)listCell.ElementAt(i);
                    //if (this.isRowEven)
                    //{

                    //    if (viewCell.View != null)
                    //    {

                    //        //   viewCell.View.BackgroundColor = Color.Gray;
                    //        var label = (Label)viewCell.FindByName("column");
                    //        var label2 = (Label)viewCell.FindByName("column1");
                    //        var label3 = (Label)viewCell.FindByName("column2");
                    //        var label4 = (Label)viewCell.FindByName("column3");

                    //        ChangeLabelColorToOther(label, Color.Gray);
                    //        ChangeLabelColorToOther(label2, Color.Gray);
                    //        ChangeLabelColorToOther(label3, Color.Gray);
                    //        ChangeLabelColorToOther(label4, Color.Gray);



                    //        //label4.IsVisible = false;
                    //    }

                    //}

                    if (this.isHideColumn==true)
                    {
                        var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");

                        gridcolumn.Width = 0;

                        isHideColumn = false;
                      
                    }
                    else
                    {
                        var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");
                        gridcolumn.Width = 1;

                        isHideColumn = true;
                        
                    }


                    
                }



                listCell = listCell;
            }
        }
       


    }
}