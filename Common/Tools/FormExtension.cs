using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Common.Tools
{
    public static class FormExtension
    {
        private const string FORMGROUP = "<div class=\"form-group\">{0}<div class=\"col-sm-10\">{1}{2}</div></div>";
        private const string FORMGROUPCHECKBOX = "<div class=\"form-group\">{0}<div class=\"col-sm-10 checkbox\">{1}{2}</div></div>";

        /// <summary>
        /// TextBoxFor avec formmatage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString TextBoxBootstrap<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return Format(html, expression, html.TextBoxFor(expression, new { @class = "form-control" }).ToString());
        }

        /// <summary>
        /// TextAreaFor avec formattage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString TextBoxAreaBootstrap<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return Format(html, expression, html.TextAreaFor(expression, new { @class = "form-control" }).ToString());
        }

        /// <summary>
        /// TextBoxFor avec style DatePicker avec formattage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString DatePickerBootstrap<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return Format(html, expression, html.EditorFor(expression, new { @htmlattributes = new { @class = "form-control datePicker", @type = "text" }}).ToString());
        }

        /// <summary>
        /// TextBoxFor avec style DatePicker avec formattage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString DateTimePickerBootstrap<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return Format(html, expression, html.EditorFor(expression, new { @htmlattributes = new { @class = "form-control dateTimePicker", @type = "text" }}).ToString());
        }

        /// <summary>
        /// CheckBoxFor avec formattage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxBootstrap<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, bool>> expression)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<label>");
            sb.Append(html.CheckBoxFor(expression).ToString());
            sb.Append("</label>");
            return MvcHtmlString.Create(
                string.Format(
                    FORMGROUPCHECKBOX,
                    html.LabelFor(expression, new { @class = "col-sm-2 control-label" }).ToString(),
                    sb.ToString(),
                    html.ValidationMessageFor(expression).ToString()));
        }

        /// <summary>
        /// DropDownListFor avec formmattage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="selectList"></param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListBootstrap<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
        {
            return Format(html, expression, html.DropDownListFor(expression, selectList, new { @class = "form-control", @multiple = "" }).ToString());
        }

        public static MvcHtmlString DropDownListEnumBootstrap<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, bool pMultipleSelect)
        {
            if (pMultipleSelect)
            {
                return Format(html, expression, html.EnumDropDownListFor(expression, new { @class = "form-control", @multiple = "" }).ToString());
            }
            else
            {
                return Format(html, expression, html.EnumDropDownListFor(expression, new { @class = "form-control" }).ToString());
            }
        }

        /// <summary>
        /// Boutton Submit avec formattage Bootstrap
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="html"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static MvcHtmlString SubmitBootstrap<TModel>(this HtmlHelper<TModel> html, string pValue)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"col-sm-offset-2 col-sm-10\">");
            sb.Append("<button type=\"submit\" class=\"btn btn-primary\">Valider</button>");
            return MvcHtmlString.Create($"<div class=\"form-group\">{sb.ToString()}</div></div>");
        }

        private static MvcHtmlString Format<TModel, TValue>(HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string pStringToFormat)
        {
            return MvcHtmlString.Create(
                string.Format(
                    FORMGROUP,
                    html.LabelFor(expression, new { @class = "col-sm-2 control-label" }).ToString(),
                    pStringToFormat,
                    html.ValidationMessageFor(expression).ToString()));
        }
    }
}