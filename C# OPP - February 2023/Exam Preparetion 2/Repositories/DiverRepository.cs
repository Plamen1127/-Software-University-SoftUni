﻿using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> divers;
        public DiverRepository()
        {
            this.divers = new List<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models
        {
            get { return this.divers.AsReadOnly(); }
        }

        public void AddModel(IDiver model)
        {
            divers.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}
