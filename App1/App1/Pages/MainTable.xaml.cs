using App1.Models;
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
        public ObservableCollection<MainTableModel> MyItems { get; set; }
        public MainTable()
        {
            InitializeComponent();

            MyItems = new ObservableCollection<MainTableModel>();



            for (int i = 0; i < 100; i++)
            {
                MyItems.Add(new MainTableModel { Number = i.ToString(), Material = "Пластик", TechnicalConditionDescription = "Очень очень очень очень много букав", WearRate = 2.5, СonstructiveItemsDescription = "Тоже очень много букав" });
            }

            isRowEven = true;
            var headergridcolumn = (ColumnDefinition)HeaderGrid.FindByName("headergridcolumn1");
            headergridcolumn.Width = new GridLength(1, GridUnitType.Star) { };

            IEnumerable<PropertyInfo> pInfos = (listViewm as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            if (templatedItems != null)
            {
                var cells = templatedItems.GetValue(listViewm);
                Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell> listCell = cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>;
                for (int i = 0; i < listCell.Count; i++)
                {
                    var viewCell = (ViewCell)listCell.ElementAt(i);
                    if (this.isRowEven)
                    {

                        if (viewCell.View != null)
                        {

                            //   viewCell.View.BackgroundColor = Color.Gray;
                            var label = (Label)viewCell.FindByName("column");
                            var label2 = (Label)viewCell.FindByName("column1");
                            var label3 = (Label)viewCell.FindByName("column2");
                            var label4 = (Label)viewCell.FindByName("column3");
                            var label5 = (Label)viewCell.FindByName("column4");

                            ChangeLabelColorToOther(label, Color.LightYellow);
                            ChangeLabelColorToOther(label2, Color.LightYellow);
                            ChangeLabelColorToOther(label3, Color.LightYellow);
                            ChangeLabelColorToOther(label4, Color.LightYellow);
                            ChangeLabelColorToOther(label5, Color.LightYellow);
                        }

                    }

                    isRowEven = !isRowEven;
                    var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");

                    gridcolumn.Width = new GridLength(1, GridUnitType.Star) { };

                }
            }


            isHideColumn = true;

            

            this.BindingContext = this;
        }

        private bool isRowEven;
        private bool isHideColumn;

        private void Cell_OnAppearing(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            isRowEven = true;
            var headergridcolumn = (ColumnDefinition)HeaderGrid.FindByName("headergridcolumn1");
            headergridcolumn.Width = new GridLength(1, GridUnitType.Star) { };

            IEnumerable<PropertyInfo> pInfos = (listViewm as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            if (templatedItems != null)
            {
                var cells = templatedItems.GetValue(listViewm);
                Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell> listCell = cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>;
                for (int i = 0; i < listCell.Count; i++)
                {
                    var viewCell = (ViewCell)listCell.ElementAt(i);
                    if (this.isRowEven)
                    {

                        if (viewCell.View != null)
                        {

                            //   viewCell.View.BackgroundColor = Color.Gray;
                            var label = (Label)viewCell.FindByName("column");
                            var label2 = (Label)viewCell.FindByName("column1");
                            var label3 = (Label)viewCell.FindByName("column2");
                            var label4 = (Label)viewCell.FindByName("column3");
                            var label5 = (Label)viewCell.FindByName("column4");

                            ChangeLabelColorToOther(label, Color.LightYellow);
                            ChangeLabelColorToOther(label2, Color.LightYellow);
                            ChangeLabelColorToOther(label3, Color.LightYellow);
                            ChangeLabelColorToOther(label4, Color.LightYellow);
                            ChangeLabelColorToOther(label5, Color.LightYellow);
                        }

                    }

                    isRowEven = !isRowEven;
                    var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");

                    gridcolumn.Width = new GridLength(1, GridUnitType.Star) { };

                }
            }
        }

        private void ChangeLabelColorToOther(Label label,Color color)
        {
            label.BackgroundColor = color;
        }

        private void HideAndShowColumn(object sender, EventArgs e)
        {
            if (this.isHideColumn == true)
            {
                var headergridcolumn = (ColumnDefinition)HeaderGrid.FindByName("headergridcolumn1");
                headergridcolumn.Width = new GridLength(0, GridUnitType.Star) { };
                isRowEven = true;
                IEnumerable<PropertyInfo> pInfos = (listViewm as ItemsView<Cell>).GetType().GetRuntimeProperties();
                var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
                if (templatedItems != null)
                {
                    var cells = templatedItems.GetValue(listViewm);
                    Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell> listCell = cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>;
                    for (int i = 0; i < listCell.Count; i++)
                    {
                        var viewCell = (ViewCell)listCell.ElementAt(i);
                        if (this.isRowEven)
                        {

                            if (viewCell.View != null)
                            {

                                //   viewCell.View.BackgroundColor = Color.Gray;
                                var label = (Label)viewCell.FindByName("column");
                                var label2 = (Label)viewCell.FindByName("column1");
                                var label3 = (Label)viewCell.FindByName("column2");
                                var label4 = (Label)viewCell.FindByName("column3");
                                var label5 = (Label)viewCell.FindByName("column4");

                                ChangeLabelColorToOther(label, Color.LightYellow);
                                ChangeLabelColorToOther(label2, Color.LightYellow);
                                ChangeLabelColorToOther(label3, Color.LightYellow);
                                ChangeLabelColorToOther(label4, Color.LightYellow);
                                ChangeLabelColorToOther(label5, Color.LightYellow);


                                //label4.IsVisible = false;
                            }

                        }

                        isRowEven = !isRowEven;

                        var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");

                            gridcolumn.Width = 0;
                        

                    }
                }


                isHideColumn = false;
            }
            else
            {
                isRowEven = true;
                var headergridcolumn = (ColumnDefinition)HeaderGrid.FindByName("headergridcolumn1");
                headergridcolumn.Width = new GridLength(1, GridUnitType.Star) { };

                IEnumerable<PropertyInfo> pInfos = (listViewm as ItemsView<Cell>).GetType().GetRuntimeProperties();
                var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
                if (templatedItems != null)
                {
                    var cells = templatedItems.GetValue(listViewm);
                    Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell> listCell = cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>;
                    for (int i = 0; i < listCell.Count; i++)
                    {
                        var viewCell = (ViewCell)listCell.ElementAt(i);
                        if (this.isRowEven)
                        {

                            if (viewCell.View != null)
                            {

                                //   viewCell.View.BackgroundColor = Color.Gray;
                                var label = (Label)viewCell.FindByName("column");
                                var label2 = (Label)viewCell.FindByName("column1");
                                var label3 = (Label)viewCell.FindByName("column2");
                                var label4 = (Label)viewCell.FindByName("column3");
                                var label5 = (Label)viewCell.FindByName("column4");

                                ChangeLabelColorToOther(label, Color.LightYellow);
                                ChangeLabelColorToOther(label2, Color.LightYellow);
                                ChangeLabelColorToOther(label3, Color.LightYellow);
                                ChangeLabelColorToOther(label4, Color.LightYellow);
                                ChangeLabelColorToOther(label5, Color.LightYellow);
                            }

                        }

                        isRowEven = !isRowEven;
                        var gridcolumn = (ColumnDefinition)viewCell.FindByName("gridcolumn1");

                        gridcolumn.Width = new GridLength(1, GridUnitType.Star) { };

                    }
                }


                isHideColumn = true;
            }
        
        }
       


    }

  
}