using BoardGames2NET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BoardGames2NET.Classes.StaticUtils
{
    /// <summary>
    /// Util class containing all methods useful for managing windows.
    /// </summary>
    public class UWindow
    {
        #region ===== METHODS =====
        /// <summary>
        /// Get all children of type <typeparamref name="T"/> given a parent <paramref name="depObj"/>.
        /// </summary>
        /// <typeparam name="T">Type of children to get.<br/><typeparamref name="T"/> must be inherited from <see cref="DependencyObject"/>.</typeparam>
        /// <param name="depObj">Parent where get all children.</param>
        /// <returns>All <typeparamref name="T"/> : <see cref="DependencyObject"/> children from the parent.</returns>
        public static IEnumerable<T>? GetChildrenOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            List<T> children = new List<T>(0);

            if (depObj == null)
            {
                return null;
            }

            foreach (var child in LogicalTreeHelper.GetChildren(depObj))
            {
                if (child is DependencyObject)
                {
                    if (child is T)
                    {
                        T? item = child as T;

                        if (item != null)
                        {
                            children.Add(item);
                        }
                    }

                    IEnumerable<T>? subChildren = GetChildrenOfType<T>(child as DependencyObject);

                    if (subChildren != null)
                    {
                        children.AddRange(subChildren);
                    } 
                }
            }

            return children;
        }

        /// <summary>
        /// Retrieve all <see cref="ContentControl"/> that are implemented with interface <see cref="ITranslatable"/>, then is translatable.
        /// </summary>
        /// <param name="depObj">Parent where get all translatable element.</param>
        /// <returns>All translatable elements from the parent.</returns>
        public static IEnumerable<ITranslatable>? GetTranslatableChildren(DependencyObject depObj)
        {
            IEnumerable<ContentControl>? elements = GetChildrenOfType<ContentControl>(depObj);

            if (elements != null)
            {
                foreach (ContentControl obj in elements)
                {
                    if (obj is ITranslatable)
                    {
                        yield return (ITranslatable)obj;
                    }
                }
            }
        }
        #endregion
    }
}
