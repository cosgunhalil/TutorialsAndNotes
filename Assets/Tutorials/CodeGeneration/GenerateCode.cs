using System;
using System.IO;
using UnityEditor;
using UnityEngine;

static class GenerateCode
{
	// Generate all code for the project
	[MenuItem("My Project/Generate Code")]
	static void Generate()
	{
		//// Generate List<T> extensions
		//GenerateSimpleTemplate(
		//	"TYPEListExtensions",
		//	typeof(Vector2),
		//	"Extensions",
		//	"Vector2ListExtensions"
		//);
		//GenerateSimpleTemplate(
		//	"TYPEListExtensions",
		//	typeof(Vector3),
		//	"Extensions",
		//	"Vector3ListExtensions"
		//);
		//GenerateSimpleTemplate(
		//	"TYPEListExtensions",
		//	typeof(Vector4),
		//	"Extensions",
		//	"Vector4ListExtensions"
		//);


	}

	static void GenerateSimpleTemplate(
		string templateName,
		Type type,
		string intoNamespace,
		string intoType
	)
	{
		// Read the template from ProjectDir/Templates/{templateName}.cs
		string assetsDirPath = Application.dataPath;
		string projectDirPath = Directory.GetParent(assetsDirPath).FullName;
		string templatesDirPath = Path.Combine(projectDirPath, "Templates");
		string templatePath = Path.Combine(templatesDirPath, templateName) + ".cs";
		string template = File.ReadAllText(templatePath);

		// Replace variables in the template
		string result = template
			.Replace("TYPENAMESPACE", type.Namespace)
			.Replace("INTONAMESPACE", intoNamespace)
			.Replace("INTOTYPE", intoType)
			.Replace("TYPE", type.Name);

		// Output the result and create directories as necessary
		string[] intoNamespaceParts = intoNamespace.Split('.');
		string intoPath = assetsDirPath;
		for (int i = 0, len = intoNamespaceParts.Length; i < len; ++i)
		{
			string part = intoNamespaceParts[i];
			intoPath = Path.Combine(intoPath, part);
			if (!Directory.Exists(intoPath))
			{
				Directory.CreateDirectory(intoPath);
			}
		}
		intoPath = Path.Combine(intoPath, intoType);
		intoPath += ".cs";
		File.WriteAllText(intoPath, result);

		// Refresh the asset database to show the (potentially) new file
		AssetDatabase.Refresh();
	}

    static void GenerateScript()
    {
        
    }
}