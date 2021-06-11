//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.14.0
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	// Mixin Content Type with alias "footerContainer"
	/// <summary>Footer container</summary>
	public partial interface IFooterContainer : IPublishedContent
	{
		/// <summary>Copyright</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		string TCopyright { get; }

		/// <summary>Footer icon-link items</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.FooterIconItems> TLinks { get; }
	}

	/// <summary>Footer container</summary>
	[PublishedModel("footerContainer")]
	public partial class FooterContainer : PublishedContentModel, IFooterContainer
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		public new const string ModelTypeAlias = "footerContainer";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<FooterContainer, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public FooterContainer(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Copyright: Enter copyright
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		[ImplementPropertyType("tCopyright")]
		public virtual string TCopyright => GetTCopyright(this);

		/// <summary>Static getter for Copyright</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		public static string GetTCopyright(IFooterContainer that) => that.Value<string>("tCopyright");

		///<summary>
		/// Footer icon-link items
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		[ImplementPropertyType("tLInks")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.FooterIconItems> TLinks => GetTLinks(this);

		/// <summary>Static getter for Footer icon-link items</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.14.0")]
		public static global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.FooterIconItems> GetTLinks(IFooterContainer that) => that.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Web.PublishedModels.FooterIconItems>>("tLInks");
	}
}