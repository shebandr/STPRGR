using Microsoft.VisualStudio.TestTools.UnitTesting;
using STPRGR;

namespace STPRGR.Tests
{
	[TestClass]
	public class MainViewModelTests
	{
		[TestMethod]
		public void AddSymbol_AddsDigitToInputText()
		{
			// Arrange
			var viewModel = new MainViewModel();
			string digit = "5";

			// Act
			viewModel.AddSymbol(digit);

			// Assert
			Assert.AreEqual("5", viewModel.InputText);
		}

		[TestMethod]
		public void AddSymbol_AddsDecimalPointToRealPart()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.InputText = "15";

			// Act
			viewModel.AddSymbol(".");

			// Assert
			Assert.AreEqual("15.", viewModel.InputText);
		}

		[TestMethod]
		public void AddSymbol_AddsDecimalPointToImaginaryPart()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.InputText = "15i2";

			// Act
			viewModel.AddSymbol(".");

			// Assert
			Assert.AreEqual("15i2.", viewModel.InputText);
		}

		[TestMethod]
		public void Calculate_ClearsInputText()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.InputText = "15i2";

			// Act
			viewModel.Calculate("C");

			// Assert
			Assert.AreEqual("", viewModel.InputText);
		}

		[TestMethod]
		public void Calculate_StoresInMemory()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.InputText = "15i2";

			// Act
			viewModel.Calculate("MIn");

			// Assert
			Assert.AreEqual("15i2", viewModel.MemoryLabelText);
		}

		[TestMethod]
		public void Calculate_RetrievesFromMemory()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.MemoryLabelText = "15i2";

			// Act
			viewModel.Calculate("MOut");

			// Assert
			Assert.AreEqual("15i2", viewModel.InputText);
		}

		[TestMethod]
		public void Calculate_CalculatesModulus()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.InputText = "3i4";

			// Act
			viewModel.Calculate("Mod");

			// Assert
			Assert.AreEqual("5", viewModel.InputText);
		}


		[TestMethod]
		public void CheckInput_ValidRealNumber()
		{
			// Arrange
			var viewModel = new MainViewModel();
			string input = "15.5";

			// Act
			bool result = viewModel.CheckInput(input);

			// Assert
			Assert.IsTrue(result);
		}


		[TestMethod]
		public void Calculate_CalculatesArgumentInDegrees()
		{
			// Arrange
			var viewModel = new MainViewModel();
			viewModel.InputText = "1i1";

			// Act
			viewModel.Calculate("Deg");

			// Assert
			Assert.AreEqual("45", viewModel.InputText);
		}


	}
}