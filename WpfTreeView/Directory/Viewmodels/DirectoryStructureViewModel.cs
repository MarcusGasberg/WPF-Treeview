using System.Linq;
using System.Collections.ObjectModel;
namespace WpfTreeView
{
    /// <summary>
    /// The view model for the applications main Directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// A list of all directoies on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            //Get logical drives
            var children = DirectoryStructure.GetLogicalDrives();
            //Create the view models from the data
            this.Items = new ObservableCollection<DirectoryItemViewModel>(children.Select(drive => new DirectoryItemViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }
        #endregion

    }
}
