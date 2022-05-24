using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestListBox.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting => "Welcome to Avalonia!";
        private readonly ObservableAsPropertyHelper<IEnumerable<ListBoxItem>> _dbSearchResults;
        public IEnumerable<ListBoxItem> DbSearchResults2 => _dbSearchResults.Value;
        private string? _serverName;
        public string? ServerName
        {
            get => _serverName;
            set => this.RaiseAndSetIfChanged(ref _serverName, value);
        }
        public MainWindowViewModel()
        {
            EnumerateDatabases2 = ReactiveCommand.CreateFromTask<string, IEnumerable<ListBoxItem>>(async (x) =>
            {
                //static list to reproduce issue
                return new ListBoxItem[] { new ListBoxItem { Content = "test" }, new ListBoxItem { Content = "test2" }, new ListBoxItem { Content = "test3" } };
            });
            _dbSearchResults = EnumerateDatabases2.ToProperty(this, x => x.DbSearchResults2, scheduler: RxApp.MainThreadScheduler);

        }
        public ReactiveCommand<string, IEnumerable<ListBoxItem>> EnumerateDatabases2 { get; }

    }
}
