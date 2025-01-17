﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public interface IConfigurationService
    {
        void CreateDefault(string path = null);

        int Count { get; }

        int TotalCount { get;  }

        bool Load();

        void Save();

        T Get<T>(string key, string parent = null, object defaultValue = null);

        object Get(string key, string parent = null, object defaultValue = null);

        void Set(string key, string parent = null, object value = null);
    }
}
