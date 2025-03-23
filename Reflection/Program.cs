using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path of the assembly (DLL or EXE): ");
            string assemblyPath = Console.ReadLine();

            if (string.IsNullOrEmpty(assemblyPath))
            {
                Console.WriteLine("Invalid path. Exiting...");
                return;
            }

            try
            {
                // Load the assembly
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                Console.WriteLine($"\nAssembly: {assembly.FullName}");

                // Iterate through each module in the assembly
                foreach (Module module in assembly.GetModules())
                {
                    Console.WriteLine($"  Module: {module.Name}");

                    // Iterate through each class in the module
                    foreach (Type type in module.GetTypes())
                    {
                        if (type.IsClass)
                        {
                            Console.WriteLine($"    Class: {type.FullName}");

                            // Get Constructors
                            foreach (ConstructorInfo constructor in type.GetConstructors())
                            {
                                Console.WriteLine($"      Constructor: {constructor.Name} ({string.Join(", ", GetParameterInfo(constructor.GetParameters()))})");
                            }

                            // Get Methods
                            foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                            {
                                Console.WriteLine($"        Method: {method.Name} ({string.Join(", ", GetParameterInfo(method.GetParameters()))})");
                            }

                            // Get Properties
                            foreach (PropertyInfo property in type.GetProperties())
                            {
                                Console.WriteLine($"        Property: {property.Name} (Type: {property.PropertyType.Name})");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading assembly: " + ex.Message);
            }
        }

        static string[] GetParameterInfo(ParameterInfo[] parameters)
        {
            string[] paramInfo = new string[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                paramInfo[i] = $"{parameters[i].ParameterType.Name} {parameters[i].Name}";
            }
            return paramInfo;
        }
    }
}

/* Sample Ouput
E:\Wipro\DelegatesCalculator\bin\Debug\net7.0\DelegatesCalculator.dll
    Enter the path of the assembly (DLL or EXE): E:\Wipro\DelegatesCalculator\bin\Debug\net7.0\DelegatesCalculator.dll

Assembly: DelegatesCalculator, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null
  Module: DelegatesCalculator.dll
    Class: Microsoft.CodeAnalysis.EmbeddedAttribute
      Constructor: .ctor()
        Property: TypeId(Type: Object)
    Class: System.Runtime.CompilerServices.NullableAttribute
      Constructor: .ctor(Byte)
      Constructor: .ctor(Byte[])
        Property: TypeId(Type: Object)
    Class: System.Runtime.CompilerServices.NullableContextAttribute
      Constructor: .ctor(Byte)
        Property: TypeId(Type: Object)
    Class: System.Runtime.CompilerServices.RefSafetyRulesAttribute
      Constructor: .ctor(Int32)
        Property: TypeId(Type: Object)
    Class: DelegatesCalculator.MathOperation
      Constructor: .ctor(Object object, IntPtr method)
        Method: Invoke(Double a, Double b)
        Method: BeginInvoke(Double a, Double b, AsyncCallback callback, Object object)
        Method: EndInvoke(IAsyncResult result)
        Property: Target(Type: Object)
        Property: Method(Type: MethodInfo)
    Class: DelegatesCalculator.Calculator
      Constructor: .ctor()
    Class: DelegatesCalculator.Program
      Constructor: .ctor()

E:\Wipro\Reflection\bin\Debug\net7.0\Reflection.exe (process 2132) exited with code 0.
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
Press any key to close this window . . . **/
