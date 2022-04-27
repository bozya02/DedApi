using System;
using System.Collections.Generic;
using System.Text;

namespace DedApi.Model
{
    public class RootModel
    {
        public int count { get; set; }
        public List<EntryModel> entries { get; set; }
    }
}
