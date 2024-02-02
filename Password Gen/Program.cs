using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

internal class Program
{

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool CloseClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);

    const uint CF_UNICODETEXT = 13;

    private static void Main(string[] args)
    {
        Console.Clear();
        Console.Title = "Password Generator";
        Console.ForegroundColor
                    = ConsoleColor.Blue;
        Console.WriteLine("");
        Console.WriteLine("\r\n ░██████╗░███████╗███╗░░██╗███████╗██████╗░░█████╗░████████╗░█████╗░██████╗░\r\n ██╔════╝░██╔════╝████╗░██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██╔══██╗\r\n ██║░░██╗░█████╗░░██╔██╗██║█████╗░░██████╔╝███████║░░░██║░░░██║░░██║██████╔╝\r\n ██║░░╚██╗██╔══╝░░██║╚████║██╔══╝░░██╔══██╗██╔══██║░░░██║░░░██║░░██║██╔══██╗\r\n ╚██████╔╝███████╗██║░╚███║███████╗██║░░██║██║░░██║░░░██║░░░╚█████╔╝██║░░██║\r\n ░╚═════╝░╚══════╝╚═╝░░╚══╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░╚═╝░░╚═╝");
        Console.ForegroundColor
                    = ConsoleColor.DarkBlue;
        Console.WriteLine("");
        Console.WriteLine("                   Password Generator   |   @soacy");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.Write(" [ ");
        Console.ForegroundColor
                    = ConsoleColor.Blue;
        Console.Write("8 - 24");
        Console.ForegroundColor
                    = ConsoleColor.DarkBlue;
        Console.Write(" ] ");
        Console.ForegroundColor
                    = ConsoleColor.Blue;
        Console.Write(" Please enter the number of characters you would like in your password.");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.ForegroundColor
                    = ConsoleColor.White;
        Console.Write("  > ");

        if (int.TryParse(Console.ReadLine(), out int passwordLength))
        {
            if (passwordLength >= 8 && passwordLength <= 24)
            {
                string password = GeneratePassword(passwordLength);
                Console.WriteLine("");
                Console.ForegroundColor
                            = ConsoleColor.DarkBlue;
                Console.Write(" [ ");
                Console.ForegroundColor
                            = ConsoleColor.Blue;
                Console.Write("!");
                Console.ForegroundColor
                            = ConsoleColor.DarkBlue;
                Console.Write(" ] ");
                Console.ForegroundColor
                            = ConsoleColor.Blue;
                Console.Write(" Your generated password: ");
                Console.ForegroundColor
                    = ConsoleColor.White;
                Console.Write($"{password}\n");
                Console.ForegroundColor
                    = ConsoleColor.Blue;
                Console.WriteLine("");
                Console.ForegroundColor
                            = ConsoleColor.DarkBlue;
                Console.Write(" [ ");
                Console.ForegroundColor
                            = ConsoleColor.Blue;
                Console.Write("-");
                Console.ForegroundColor
                            = ConsoleColor.DarkBlue;
                Console.Write(" ] ");
                Console.ForegroundColor
                            = ConsoleColor.Blue;
                Console.Write(" Press any key to copy the password to the clipboard.\n");
                Console.WriteLine("");
                Console.ForegroundColor
                            = ConsoleColor.White;
                Console.Write("  > ");
                Console.ReadKey();

                SetClipboardText(password);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor
            = ConsoleColor.DarkBlue;
                Console.Write(" [ ");
                Console.ForegroundColor
                            = ConsoleColor.Blue;
                Console.Write("!");
                Console.ForegroundColor
                            = ConsoleColor.DarkBlue;
                Console.Write(" ] ");
                Console.ForegroundColor
                            = ConsoleColor.Blue;
                Console.Write(" Password copied to clipboard!");
                Thread.Sleep(2000);
            }
        }

        else
        {

        }

        static string GeneratePassword(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=<>?";

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                password.Append(chars[index]);
            }

            return password.ToString();
        }

        static void SetClipboardText(string text)
        {
            OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(text);

            SetClipboardData(CF_UNICODETEXT, ptr);

            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }
}