using NUnit.Framework;

namespace IntegerArithmeticRsaEncryption {
	internal class RSA_Tests {
		[TestCase("hello", "101", "103", TestName = "WhenUsualNumbers")]
		[TestCase("hello", "5037569", "5810011", TestName = "WhenBigNumbers")]
		public void CorrectDecode(string value, string number1, string number2) {
			var p = new BigInt(number1);
			var q = new BigInt(number2);
			var modulo = p * q;
			var phi = (p - new BigInt("1")) * (q - new BigInt("1"));
			var publicExponent = RSA.CalculatePublicExponent(phi);
			var secretExponent = RSA.CalculateSecretExponent(publicExponent, phi);

			var encoded = RSA.Encode(value, publicExponent, modulo);
			var decoded = RSA.Decode(encoded, secretExponent, modulo);

			Assert.AreEqual(value, decoded);
		}
	}
}