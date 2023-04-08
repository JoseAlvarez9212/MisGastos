using System.Threading.Tasks;

namespace MisGastos.Prism.Test.Extensions
{
    /// <summary>
    /// Extensions for ViewModelTest
    /// </summary>
	public static class Extensions
	{
        /// <summary>
        /// Run task on trycatch.
        /// </summary>
        /// <param name="task">Task to check.</param>
        /// <returns>True if ok in other wise false.</returns>
        public static async Task<bool> RunWithoutExceptionsAsync(this Task task)
        {
            //Act
            try
            {
                await task;
                return true;
            }
            //Assert
            catch
            {
                return false;
            }
        }
    }
}

