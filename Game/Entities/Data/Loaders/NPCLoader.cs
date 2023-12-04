﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Navislamia.Database;
using Navislamia.Data.Interfaces;
using Navislamia.Data.Repositories;
using Navislamia.Notification;

namespace Navislamia.Data.Loaders;

public class NPCLoader : RepositoryLoader, IRepositoryLoader
{

    public NPCLoader(INotificationModule notificationModule) : base(notificationModule)
    {
    }

    public List<IRepository> Init()
    {
        // Tasks.Add(Task.Run(() => new NPCRepository(_dbConnectionManager.WorldConnection).Load()));

        if (!Execute())
            return null;

        return this.Repositories;
    }
}
