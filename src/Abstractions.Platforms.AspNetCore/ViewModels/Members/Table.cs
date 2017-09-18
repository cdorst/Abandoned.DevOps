using System;
using System.Collections.Generic;
using System.Text;

namespace DevOps.Abstractions.Platforms.AspNetCore.ViewModels.Members
{
    public class Table
    {
        public List<TableColumnHeader> ColumnHeaders { get; set; }
        public List<TableRow> Rows { get; set; }
    }

    public class TableColumnHeader
    {
        public string Value { get; set; }
        public string Href { get; set; }
    }
    // How to accomodate hyperlinks in table column headers?

    public class Hyperlink
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Dictionary<string, object> RouteValues { get; set; }
    }

    public class TableRow
    {
    }
}
