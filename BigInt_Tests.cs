using NUnit.Framework;
using System;

namespace IntegerArithmeticRsaEncryption {
	internal class BigIntTests {
		[TestCase("256", "256", true, TestName = "WhenSamePositiveNumbersEquals")]
		[TestCase("256", "26", false, TestName = "WhenPositiveNumbersEquals")]
		[TestCase("-256", "-256", true, TestName = "WhenSameNegativeNumbersEquals")]
		[TestCase("-256", "-26", false, TestName = "WhenNegativeNumbersEquals")]
		[TestCase("256", "-26", false, TestName = "WhenPositiveAndNegativeNumbersEquals")]
		public void CorrectEqual(string value1, string value2, bool isEqual) {
			Assert.AreEqual(isEqual, new BigInt(value1) == new BigInt(value2));
		}

		[TestCase("256", "256", false, TestName = "WhenSamePositiveNumbersMore")]
		[TestCase("256", "26", true, TestName = "WhenPositiveNumbersMore")]
		[TestCase("-256", "-256", false, TestName = "WhenSameNegativeNumbersMore")]
		[TestCase("-26", "-256", true, TestName = "WhenNegativeNumbersMore")]
		[TestCase("26", "-256", true, TestName = "WhenPositiveAndNegativeNumbersMore")]
		public void CorrectCompare_GreaterThan(string value1, string value2, bool isEqual) {
			Assert.AreEqual(isEqual, new BigInt(value1) > new BigInt(value2));
		}

		[TestCase("264", "264", false, TestName = "WhenSamePositiveNumbersLess")]
		[TestCase("25", "26", true, TestName = "WhenPositiveNumbersLess")]
		[TestCase("-256", "-256", false, TestName = "WhenSameNegativeNumbersLess")]
		[TestCase("-257", "-256", true, TestName = "WhenNegativeNumbersLess")]
		[TestCase("-26", "26", true, TestName = "WhenPositiveAndNegativeNumbersLess")]
		public void CorrectCompare_LessThan(string value1, string value2, bool isEqual) {
			var first = new BigInt(value1);
			Assert.AreEqual(isEqual, first < new BigInt(value2));
		}

		[TestCase("847", "178", "1025", TestName = "WhenNumbersHaveSameLengthPositiveAddition")]
		[TestCase("95841", "177478", "273319", TestName = "WhenLeftNumberIsShorterPositiveAddition")]
		[TestCase("177478", "95841", "273319", TestName = "WhenRightNumberIsShorterPositiveAddition")]
		[TestCase("17747984891984498489498489", "494981874984984894984984", "18242966766969483384483473",
			TestName = "WhenBigNumbersPositiveAddition")]
		public void CorrectAddition_WhenBothNumberArePositive(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 + number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("-847", "-178", "-1025", TestName = "WhenNumbersHaveSameLengthNegativeAddition")]
		[TestCase("-95841", "-177478", "-273319", TestName = "WhenLeftNumberIsShorterNegativeAddition")]
		[TestCase("-177478", "-95841", "-273319", TestName = "WhenRightNumberIsShorterNegativeAddition")]
		[TestCase("-17747984891984498489498489", "-494981874984984894984984", "-18242966766969483384483473",
			TestName = "WhenBigNumbersNegativeAddition")]
		public void CorrectAddition_WhenBothNumberAreNegative(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 + number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("-847", "178", "-669", TestName = "WhenNumbersHaveSameLengthPositiveAndNegativeAddition")]
		[TestCase("-95841", "177478", "81637", TestName = "WhenLeftNumberIsNegativeAddition")]
		[TestCase("177478", "-95841", "81637", TestName = "WhenRightNumberIsNegativeAddition")]
		[TestCase("17747984891984498489498489", "-41949818749849848949840984", "-24201833857865350460342495",
			TestName = "WhenBigNumbersRightNumberIsNegativeAddition")]
		public void CorrectAddition_WhenPositiveAndNegativeNumbers(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 + number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("847", "178", "669", TestName = "WhenNumbersHaveSameLengthPositiveSubtraction")]
		[TestCase("95841", "177478", "-81637", TestName = "WhenLeftNumberIsShorterPositiveSubtraction")]
		[TestCase("177478", "95841", "81637", TestName = "WhenRightNumberIsShorterPositiveSubtraction")]
		[TestCase("17747984891984498489498489", "41949818749849848949840984", "-24201833857865350460342495",
			TestName = "WhenBigNumbersPositiveSubtraction")]
		public void CorrectSubtraction_WhenBothNumberArePositive(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 - number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("-847", "-178", "-669", TestName = "WhenNumbersHaveSameLengthNegativeSubtraction")]
		[TestCase("-95841", "-177478", "81637", TestName = "WhenLeftNumberIsShorterNegativeSubtraction")]
		[TestCase("-177478", "-95841", "-81637", TestName = "WhenRightNumberIsShorterNegativeSubtraction")]
		[TestCase("-17747984891984498489498489", "-41949818749849848949840984", "24201833857865350460342495",
			TestName = "WhenBigNumbersNegativeSubtraction")]
		public void CorrectSubtraction_WhenBothNumberAreNegative(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 - number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("95841", "-177478", "273319", TestName = "WhenNumbersHaveSameLengthNegativeAndPositiveSubtraction")]
		[TestCase("-847", "178", "-1025", TestName = "WhenLeftNumberIsShorterNegativeAndPositiveSubtraction")]
		[TestCase("-177478", "95841", "-273319", TestName = "WhenRightNumberIsShorterNegativeAndPositiveSubtraction")]
		[TestCase("17747984891984498489498489", "-41949818749849848949840984", "59697803641834347439339473",
			TestName = "WhenBigNumbersNegativeAndPositiveSubtraction")]
		public void CorrectSubtraction_WhenPositiveAndNegativeNumbers(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 - number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("847", "178", "150766", TestName = "WhenBothNumbersArePositive")]
		[TestCase("-1478", "-95841", "141652998", TestName = "WhenBothNumbersAreNegative")]
		[TestCase("-177478", "15841", "-2811428998", TestName = "WhenPositiveAndNegativeNumbers")]
		[TestCase("17747984891984498489498489", "-41949818749849848949840984",
			"-744524749393823160874372569351363330891430458273176",
			TestName = "WhenBigNumbersNegativeSubtraction")]
		public void CorrectMultiplication(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 * number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("847", "178", "4", TestName = "WhenBothNumbersArePositive")]
		[TestCase("-1478", "-95841", "0", TestName = "WhenBothNumbersAreNegative")]
		[TestCase("177478", "-15841", "-11", TestName = "WhenPositiveAndNegativeNumbers")]
		[TestCase("17747984891984498489498489", "188840984", "93983755623644168",
			TestName = "WhenBigNumbers")]
		public void CorrectDivision(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 / number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("847", "178", "135", TestName = "WhenBothNumbersArePositive")]
		[TestCase("-1478", "-95841", "-1478", TestName = "WhenBothNumbersAreNegative")]
		[TestCase("177478", "-15841", "3227", TestName = "WhenPositiveAndNegativeNumbers")]
		[TestCase("17747984891984498489498489", "188840984", "138517177",
			TestName = "WhenBigNumbers")]
		public void CorrectModulo(string value1, string value2, string expectedValue) {
			var number1 = new BigInt(value1);
			var number2 = new BigInt(value2);

			var actual = number1 % number2;

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("7", "13", "2", TestName = "WhenUsualNumbers")]
		[TestCase("8948456163", "8942", "1605", TestName = "WhenBigNumbers")]
		public void CorrectInverseElementInModulo(string value, string modulo, string expectedValue) {
			var number1 = new BigInt(value);
			var number2 = new BigInt(modulo);

			var actual = BigInt.InverseElementOnModulo(number1, number2);

			Assert.AreEqual(new BigInt(expectedValue).Value, actual.Value);
		}

		[TestCase("4", "26", TestName = "WhenInverseElementDoesNotExist")]
		public void InverseElementInModulo_ThrowException(string value, string modulo) {
			var number1 = new BigInt(value);
			var number2 = new BigInt(modulo);

			Assert.Throws<InvalidOperationException>(() => BigInt.InverseElementOnModulo(number1, number2));
		}
	}
}