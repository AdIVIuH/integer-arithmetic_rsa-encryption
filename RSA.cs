using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace IntegerArithmeticRsaEncryption {
	public static class RSA {
		public static List<string> Encode(string value, BigInt publicExponent, BigInt modulo) {
			var encodedParts = new List<string>();

			foreach (var symbol in value) {
				var result = BigInteger.ModPow(new BigInt(((int)symbol).ToString()).Value, publicExponent.Value, modulo.Value);
				encodedParts.Add(result.ToString());
			}

			return encodedParts;
		}

		public static string Decode(IEnumerable<string> input, BigInt secretExponent, BigInt modulo) {
			var decodedValue = new StringBuilder();

			foreach (var item in input) {
				var result = BigInteger.ModPow(new BigInt(item).Value, secretExponent.Value, modulo.Value);
				decodedValue.Append((char)result);
			}

			return decodedValue.ToString();
		}

		public static BigInt CalculateSecretExponent(BigInt publicExponent, BigInt modulo) {
			return BigInt.InverseElementOnModulo(publicExponent, modulo);
		}

		public static BigInt CalculatePublicExponent(BigInt modulo) {
			var exponent = new BigInt("3");
			var one = new BigInt("1");

			for (var i = new BigInt("0"); i < modulo; i += one) {
				if (EuclideanAlgorithm.GreatestCommonDivisor(exponent, modulo, out _, out _) == one)
					return exponent;
				exponent += one;
			}

			return exponent;
		}

		public static bool IsSimpleNumber(BigInt number) {
			var zero = new BigInt("0");
			var one = new BigInt("1");
			var two = new BigInt("2");

			if (number < two)
				return false;

			if (number == two)
				return true;

			for (var i = two; i < number; i += one)
				if (number % i == zero)
					return false;

			return true;
		}
	}
}
