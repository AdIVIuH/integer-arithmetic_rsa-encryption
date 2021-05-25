using System;
using System.Numerics;

namespace IntegerArithmeticRsaEncryption {
	public class BigInt {
		public BigInteger Value { get; }

		public BigInt(string numbers) {
			Value = BigInteger.Parse(numbers);
		}

		public BigInt(byte[] numbers) {
			Value = new BigInteger(numbers);
		}

		public static bool operator ==(BigInt number1, BigInt number2) {
			return number1.Value == number2.Value;
		}

		public static bool operator !=(BigInt number1, BigInt number2) {
			return !(number1 == number2);
		}

		public static bool operator >(BigInt number1, BigInt number2) {
			return number1.Value > number2.Value;
		}

		public static bool operator >=(BigInt number1, BigInt number2) {
			return number1.Value >= number2.Value;
		}

		public static bool operator <(BigInt number1, BigInt number2) {
			return number1.Value < number2.Value;
		}

		public static bool operator <=(BigInt number1, BigInt number2) {
			return number1.Value <= number2.Value;
		}

		public static BigInt operator +(BigInt number1, BigInt number2) {
			return new BigInt((number1.Value + number2.Value).ToByteArray());
		}

		public static BigInt operator -(BigInt number1, BigInt number2) {
			return new BigInt((number1.Value - number2.Value).ToByteArray());
		}

		public static BigInt operator *(BigInt number1, BigInt number2) {
			return new BigInt((number1.Value * number2.Value).ToByteArray());
		}

		public static BigInt operator /(BigInt number1, BigInt number2) {
			return new BigInt((number1.Value / number2.Value).ToByteArray());
		}

		public static BigInt operator %(BigInt number1, BigInt number2) {
			return new BigInt((number1.Value % number2.Value).ToByteArray());
		}

		public static BigInt InverseElementOnModulo(BigInt number, BigInt modulo) {
			var divisor = EuclideanAlgorithm.GreatestCommonDivisor(number, modulo, out BigInt result, out _);
			if (divisor.Value != 1)
				throw new InvalidOperationException();
			result = (result % modulo + modulo) % modulo;
			return result;
		}

		public override string ToString() {
			return Value.ToString();
		}

		public override bool Equals(object obj) {
			return obj is BigInt bigInt &&
				   Value.Equals(bigInt.Value);
		}

		public override int GetHashCode() {
			return -1937169414 + Value.GetHashCode();
		}
	}
}