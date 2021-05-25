using System;
using System.IO;
using System.Linq;

namespace IntegerArithmeticRsaEncryption {
	public class Program {
		public static void Main() {
			var reader = new StreamReader("input.txt");
			var p = new BigInt(reader.ReadLine());
			Console.WriteLine($"p: {p}");
			var q = new BigInt(reader.ReadLine());
			Console.WriteLine($"q: {q}");
			var value = reader.ReadLine();
			Console.WriteLine($"Исходное сообщение: {value}");
			reader.Close();

			if (!RSA.IsSimpleNumber(p) || !RSA.IsSimpleNumber(q) || p == q) {
				Console.WriteLine("Numbers are not mutually prime!");
				return;
			}

			var modulo = p * q;
			Console.WriteLine($"Модуль: {modulo}");
			var phi = (p - new BigInt("1")) * (q - new BigInt("1"));
			Console.WriteLine($"Функция эйлера: {phi}");
			var publicExponent = RSA.CalculatePublicExponent(phi);
			Console.WriteLine($"Открытая экспонента: {publicExponent}");
			var secretExponent = RSA.CalculateSecretExponent(publicExponent, phi);
			Console.WriteLine($"Закрытая экспонента: {secretExponent}");

			var writer = new StreamWriter("encoded.txt");
			foreach (var item in RSA.Encode(value, publicExponent, modulo)) {
				writer.Write(item + " ");
			};
			writer.Close();

			reader = new StreamReader("encoded.txt");
			var encryptedMessage = reader.ReadToEnd().Trim();
			Console.WriteLine($"Зашифрованное сообщение: {encryptedMessage}");
			var decryptedMessage = RSA.Decode(encryptedMessage.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries),
				secretExponent, modulo);
			reader.Close();

			var result = new StreamWriter("output.txt");
			result.Write(decryptedMessage);
			result.Close();

			Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");
		}
	}
}
