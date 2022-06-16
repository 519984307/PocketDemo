using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PocketDemo1
{
    public class ListItem
    {
        private string _key = string.Empty;
        private string _value = string.Empty;
        public ListItem(string pKey, string pValue)
        {
            _key = pKey;
            _value = pValue;
        }
        public override string ToString()
        {
            return this._value;
        }
        public string Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        /// <summary>  
        /// 根据ListItem中的Value找到特定的ListItem(仅在ComboBox的Item都为ListItem时有效)  
        /// </summary>  
        /// <param name="cmb">要查找的ComboBox</param>  
        /// <param name="strValue">要查找ListItem的Value</param>  
        /// <returns>返回传入的ComboBox中符合条件的第一个ListItem，如果没有找到则返回null.</returns>  
        public static ListItem FindByValue(ComboBox cmb, string strValue)
        {
            foreach (ListItem li in cmb.Items)
            {
                if (li.Value == strValue)
                {
                    return li;
                }
            }
            return null;
        }

        /// <summary>  
        /// 根据ListItem中的Key找到特定的ListItem(仅在ComboBox的Item都为ListItem时有效)  
        /// </summary>  
        /// <param name="cmb">要查找的ComboBox</param>  
        /// <param name="strValue">要查找ListItem的Key</param>  
        /// <returns>返回传入的ComboBox中符合条件的第一个ListItem，如果没有找到则返回null.</returns>  
        public static ListItem FindByText(ComboBox cmb, string strText)
        {
            foreach (ListItem li in cmb.Items)
            {
                if (li.Key == strText)
                {
                    return li;
                }
            }
            return null;
        }
    }
}
