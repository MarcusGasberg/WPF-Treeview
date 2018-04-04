using System;
using System.Windows.Input;
namespace WpfTreeView
{
    public class RelayCommand : ICommand
    {
        #region Private Members
        /// <summary>
        /// The action to run
        /// </summary>
        private Action action_;
        #endregion 
        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };
        #endregion
        #region Constructor
        public RelayCommand(Action action)
        {
            action_ = action;
        }
        #endregion
        #region Command Methods
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Execture the commands Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action_();
        }
        #endregion
    }
}
