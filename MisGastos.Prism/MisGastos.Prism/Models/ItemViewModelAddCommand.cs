using System.Windows.Input;

namespace MisGastos.Prism.Models
{
    public class ItemViewModelAddCommand<T> where T : class
    {
        public T Obj { get; set; }

        public ICommand CommandContinue { get; set; }

        public ICommand CommandDetail { get; set; }

        public ItemViewModelAddCommand(T obj, ICommand commandContinue)
        {
            this.Obj = obj;
            this.CommandContinue = commandContinue;
        }

        public ItemViewModelAddCommand(T obj, ICommand commandContinue, ICommand commandDetail)
        {
            this.Obj = obj;
            this.CommandContinue = commandContinue;
            this.CommandDetail = commandDetail;
        }
    }
}

