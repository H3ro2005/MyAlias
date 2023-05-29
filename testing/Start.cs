using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace testing
{
    public class Start
    {
        public ICommand command { get; private set; }
        public async Task go() => await AppShell.Current.GoToAsync(nameof(MainPage));
        public Start()
        {
            command = new Command(async() => await go());
        }
    }
}
