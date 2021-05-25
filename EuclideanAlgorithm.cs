namespace IntegerArithmeticRsaEncryption {
	public static class EuclideanAlgorithm {
		public static BigInt GreatestCommonDivisor(BigInt a, BigInt b, out BigInt x, out BigInt y) {
			if (a.Value == 0) {
				x = new BigInt("0");
				y = new BigInt("1");

				return b;
			}

			var divisor = GreatestCommonDivisor(b % a, a,
				out var x1, out var y1);

			x = y1 - b / a * x1;
			y = x1;

			return divisor;
		}
	}
}