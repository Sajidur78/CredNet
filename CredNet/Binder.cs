using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CredNet.Interface;

namespace CredNet
{
    public class Binder
    {
        private readonly Action<object> mSourceSetter;
        private readonly Func<object> mSourceGetter;

        private readonly Action<object> mDestinationSetter;
        private readonly Func<object> mDestinationGetter;

        private readonly string mSourceProperty;
        private readonly string mDestinationProperty;

        private Type mSourceType;
        private Type mDestinationType;

        private bool mUpdatingObjects;

        public IValueConverter Converter { get; set; }

        public BindMode Mode { get; set; }

        public Binder()
        {

        }

        public Binder(string sourceProperty, object sourceObject, string destinationProperty, object destinationObject, BindMode mode = BindMode.OneWay, IValueConverter converter = null)
        {
            Converter = converter;
            mSourceProperty = sourceProperty;
            mDestinationProperty = destinationProperty;
            Mode = mode;

            var sourceType = sourceObject.GetType();
            var srcProperty = sourceType.GetProperty(sourceProperty);

            if (srcProperty == null)
            {
                throw new ArgumentException($"{sourceType.Name} does not have an accessible property named {sourceProperty}");
            }
            mSourceType = srcProperty.PropertyType;

            var destinationType = destinationObject.GetType();
            var dstProperty = destinationType.GetProperty(destinationProperty);

            if (dstProperty == null)
            {
                throw new ArgumentException($"{destinationType.Name} does not have an accessible property named {destinationProperty}");
            }

            mDestinationType = dstProperty.PropertyType;

            switch (mode)
            {
                case BindMode.OneWay:
                {
                    if (dstProperty.SetMethod != null)
                    {
                        mSourceGetter = CreatePropertyGetter(sourceObject, sourceProperty);
                        mDestinationSetter = CreatePropertySetter(destinationObject, destinationProperty);
                    }
                    else
                    {
                        throw new ArgumentException($"{sourceType.Name} does not have an accessible setter for {sourceProperty}");
                    }

                    mDestinationSetter(mSourceGetter());
                    if (sourceObject is INotifyPropertyChanged changeObject)
                    {
                        changeObject.PropertyChanged += SourcePropertyChanged;
                    }
                    break;
                }
                
                case BindMode.OneWayToSource:
                {
                    if (srcProperty.SetMethod != null)
                    {
                        mSourceSetter = CreatePropertySetter(sourceObject, sourceProperty);
                    }
                    else
                    {
                        throw new ArgumentException($"{sourceType.Name} does not have an accessible setter for {sourceProperty}");
                    }

                    goto case BindMode.TwoWay;
                }
                
                case BindMode.TwoWay:
                {
                    mDestinationGetter = CreatePropertyGetter(destinationObject, mDestinationProperty);
                    if (mSourceSetter == null)
                    {
                        if (srcProperty.SetMethod != null)
                        {
                            mSourceSetter = CreatePropertySetter(sourceObject, sourceProperty);
                        }
                        else
                        {
                            throw new ArgumentException($"{sourceType.Name} does not have an accessible setter for {sourceProperty}");
                        }
                    }
                    if (destinationObject is INotifyPropertyChanged destChangeObject)
                    {
                        destChangeObject.PropertyChanged += DestinationPropertyChanged;
                    }

                    goto case BindMode.OneWay;
                }
                default:
                    throw new ArgumentException($"Invalid mode: {mode}");
            }
        }

        private void DestinationPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!mUpdatingObjects)
            {
                mUpdatingObjects = true;
                if (e.PropertyName == mDestinationProperty)
                {
                    var value = mDestinationGetter();

                    if (Converter != null)
                    {
                        value = Converter.Convert(value, mSourceType);
                    }
                    
                    mSourceSetter(value);
                }

                mUpdatingObjects = false;
            }
        }

        private void SourcePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!mUpdatingObjects)
            {
                mUpdatingObjects = true;
                if (e.PropertyName == mSourceProperty)
                {
                    var value = mSourceGetter();

                    if (Converter != null)
                    {
                        value = Converter.ConvertBack(value, mDestinationType);
                    }

                    mDestinationSetter(value);
                }

                mUpdatingObjects = false;
            }
        }

        private static Func<object> CreatePropertyGetter(object target, string propertyName)
        {
            var body = Expression.Convert(Expression.Property(Expression.Constant(target), propertyName), typeof(object));
            return Expression.Lambda<Func<object>>(body)
                .Compile();
        }

        private static Action<object> CreatePropertySetter(object target, string propertyName)
        {
            var constExpression = Expression.Constant(target);

            ParameterExpression paramExpression = Expression.Parameter(typeof(object), propertyName);

            MemberExpression propertyGetterExpression = Expression.Property(constExpression, propertyName);

            var assignExpression = Expression.Assign(propertyGetterExpression,
                Expression.Convert(paramExpression, propertyGetterExpression.Type));

            return Expression.Lambda<Action<object>>(assignExpression, paramExpression).Compile();
        }
    }

    public enum BindMode
    {
        OneWay,
        TwoWay,
        OneWayToSource
    }
}
