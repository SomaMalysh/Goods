﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods
{
    class ClassGoods
    {
        string id;
        string name;
        string category;
        string creation_date;
        string valid_date;
        string count;
        string price;
        string provider;
        string provider_phone;
        string date_in;
        string storage;
        string short_description;
        string note;

        public string _id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string _name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public string _category
        {
            set
            {
                category = value;
            }
            get
            {
                return category;
            }
        }
        public string _creation_date
        {
            set
            {
                creation_date = value;
            }
            get
            {
                return creation_date;
            }
        }
        public string _valid_date
        {
            set
            {
                valid_date = value;
            }
            get
            {
                return valid_date;
            }
        }
        public string _count
        {
            set
            {
                count = value;
            }
            get
            {
                return count;
            }
        }
        public string _price
        {
            set
            {
                price = value;
            }
            get
            {
                return price;
            }
        }
        public string _provider
        {
            set
            {
                provider = value;
            }
            get
            {
                return provider;
            }
        }
        public string _provider_phone
        {
            set
            {
                provider_phone = value;
            }
            get
            {
                return provider_phone;
            }
        }
        public string _date_in
        {
            set
            {
                date_in = value;
            }
            get
            {
                return date_in;
            }
        }
        public string _storage
        {
            set
            {
                storage = value;
            }
            get
            {
                return storage;
            }
        }
        public string _short_description
        {
            set
            {
                short_description = value;
            }
            get
            {
                return short_description;
            }
        }
        public string _note
        {
            set
            {
                note = value;
            }
            get
            {
                return note;
            }
        }

        public ClassGoods()
        {

        }
    }    
}