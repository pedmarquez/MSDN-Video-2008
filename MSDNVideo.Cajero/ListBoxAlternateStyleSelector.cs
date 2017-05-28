using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace MSDNVideo.Cajero
{
    public class ListBoxAlternateStyleSelector : StyleSelector
    {
        private int _rowCount = 0; 
        
        public override Style SelectStyle(object item, DependencyObject container) 
        { 
            string styleKey; 
            ItemsControl ic = ItemsControl.ItemsControlFromItemContainer(container); 
            
            if (item == ic.Items[0]) 
            { 
                _rowCount = 0; 
            } 
            if (_rowCount % 2 == 0) 
            {
                styleKey = "ListBoxItemPar"; 
            } 
            else 
            {
                styleKey = "ListBoxItemImpar"; 
            }
 
            _rowCount++; 
            
            return (Style)(ic.FindResource(styleKey)); }
    }
}
