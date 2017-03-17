using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Common.Tools.Helper.Object;

namespace Common.Tools.Helper.Html.Bootstrap
{
    public static class HtmlExtension
    {

        const string ModelBalise = "<div class=\"form-group\">{0} <div class=\"col-sm-10 {3}\">{1}{2}</div></div>";

        const string CssClassLabel = "col-sm-2 control-label";
        const string CssClassEditor = "form-control";
        const string CssClassEditorDatePicker = "form-control datePicker";
        const string CssClassEditorDateTimePicker = "form-control dateTimePicker";

        /// <summary>
        /// Création d'un textbox
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes">Si != null alors il doit au moins contenir une propriété class vide</param>
        /// <returns></returns>
        public static MvcHtmlString TBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            if (htmlAttributes == null)
                htmlAttributes = new { @class = "form-control" };
            else if (!htmlAttributes.IsPropertyExist("class"))
                throw new ApplicationException("Si htmlAttributes n'est pas nul, il doit alors contenir au moins une propriété class vide.");

            string balise = System.String.Format(ModelBalise,
            html.LabelFor(expression, new { @class = CssClassLabel }),
            html.TextBoxFor(expression, htmlAttributes),
            html.ValidationMessageFor(expression),
            string.Empty
                );
            return MvcHtmlString.Create(balise);
        }

        /// <summary>
        /// Création d'une chexbox
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString CBoxFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression, object htmlAttributes = null)
        {
            string balise = System.String.Format(ModelBalise,
            html.LabelFor(expression, new { @class = CssClassLabel }),
            "<label>" + html.CheckBoxFor(expression, htmlAttributes) + "</label>",
            html.ValidationMessageFor(expression),
            "checkbox"
                );
            return MvcHtmlString.Create(balise);
        }

        /// <summary>
        /// ne prend pas en charge les classes bootstrap automatique (form-control...)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString DDownListFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            string balise = System.String.Format(
                ModelBalise,
                html.LabelFor(expression, new { @class = CssClassLabel }),
                html.DropDownListFor(expression, selectList, htmlAttributes),
                string.Empty,
                string.Empty
            );
            return MvcHtmlString.Create(balise);

        }

        public static MvcHtmlString DatePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string balise = System.String.Format(ModelBalise,
            html.LabelFor(expression, new { @class = CssClassLabel }),
            html.EditorFor(expression, new { htmlAttributes = new { @class = CssClassEditorDatePicker, type = "text" } }),
            html.ValidationMessageFor(expression),
            string.Empty
                );

            return MvcHtmlString.Create(balise);
        }

        public static MvcHtmlString DateTimePickerFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            string balise = System.String.Format(ModelBalise,
            html.LabelFor(expression, new { @class = CssClassLabel }),
            html.EditorFor(expression, new { htmlAttributes = new { @class = CssClassEditorDateTimePicker, type = "text" } }),
            html.ValidationMessageFor(expression),
            string.Empty
                );

            return MvcHtmlString.Create(balise);
        }

        public static MvcHtmlString Submit(this HtmlHelper html, string value = "Enregistrer", string onClick = null, string classe = "btn btn-default")
        {
            if (onClick != null)
                onClick = $"onclick=\"{onClick}\"";

            string balise = String.Format(ModelBalise, string.Empty,
            $"<input type=\"submit\" class=\"{classe}\" value=\"{value}\" {onClick}/>",
            string.Empty, "col-sm-offset-2");
            return MvcHtmlString.Create(balise);
        }

        public static MvcHtmlString Retour(this HtmlHelper html, string url, string value = "Retour", string classe = "btn btn-default")
        {
            string balise = String.Format(ModelBalise, string.Empty,
            $"<a type=\"button\" class=\"{classe}\" href=\"{url}\">{value}</a>",
            string.Empty, "col-sm-offset-2");
            return MvcHtmlString.Create(balise);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue">Type enuméré</typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioWithEnumFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            string radioTemplate = "<label class=\"radio-inline\">{0} {1}</label>";
            string radioList = string.Empty;

            foreach (var item in Enum.GetValues(typeof(TValue)))
            {
                radioList += string.Format(radioTemplate,
                    html.RadioButtonFor(expression, item, htmlAttributes),
                    item);
            }

            string balise = System.String.Format(ModelBalise,
            html.LabelFor(expression, new { @class = CssClassLabel }),
            radioList,
            html.ValidationMessageFor(expression), string.Empty
                );
            return MvcHtmlString.Create(balise);
        }

        public static MvcHtmlString TAeraFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            string balise = string.Format(ModelBalise,
                html.LabelFor(expression, new { @class = CssClassLabel }),
                html.TextAreaFor(expression, htmlAttributes),
                html.ValidationMessageFor(expression),
                string.Empty
            );
            return MvcHtmlString.Create(balise);
        }
    }
}
