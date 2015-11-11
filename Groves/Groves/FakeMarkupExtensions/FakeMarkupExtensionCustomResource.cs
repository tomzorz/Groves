using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Resources;

namespace Groves.FakeMarkupExtensions
{
	public class FakeMarkupExtensionCustomResource : CustomXamlResourceLoader
	{
		//todo scenairos:
		/*
		https://wpdev.uservoice.com/forums/110705-dev-platform/suggestions/7232264-add-markup-extensions-to-and-improve-winrt-xaml
		https://github.com/DragonSpark/Framework/blob/5790cd6d4ba47faceaf4d1a98c6c5ab18c6fbc61/DragonSpark/Configuration/MetadataExtension.cs#L20
		https://xamlmarkupextensions.codeplex.com/
		alternator
		custom binding, multibinding? (add datacontextproxy for that)
		*/

		public FakeMarkupExtensionCustomResource(params IFakeMarkupExtensionProvider[] fmeps)
		{

		}

		protected override object GetResource(string resourceId, string objectType, string propertyName, string propertyType)
		{
			//todo

			return null;
		}
	}
}