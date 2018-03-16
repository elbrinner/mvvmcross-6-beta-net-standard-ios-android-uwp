using System;
using Foundation;
using MvvmCross.Platform.Ios.Binding.Views;
using UIKit;

namespace Classic.IOS.DataSource
{
    public class SimpleDynamicTableViewSource : MvxTableViewSource
    {
        private Type CellType { get; set; }

        public SimpleDynamicTableViewSource(UIKit.UITableView tableView, Type cellType) : base(tableView)
        {
            this.CellType = cellType;

            tableView.Source = this;
            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.EstimatedRowHeight = 60.0f;
            this.TableView.RegisterNibForCellReuse(UINib.FromName(this.CellType.Name, null), this.CellType.Name);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return this.TableView.DequeueReusableCell(this.CellType.Name, indexPath);
        }

    }
}
