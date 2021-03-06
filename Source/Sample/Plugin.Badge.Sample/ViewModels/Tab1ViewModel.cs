﻿using Plugin.Badge.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
namespace Plugin.Badge.Sample.ViewModels
{
    public class Tab1ViewModel : INotifyPropertyChanged
    {
        private static readonly List<Color> Colors = new List<Color>()
        {
            Color.Accent,
            Color.Aqua,
            Color.Black,
            Color.Blue,
            Color.Fuchsia,
            Color.Fuchsia,
            Color.Gray,
            Color.Green,
            Color.Lime,
            Color.Maroon,
            Color.Navy,
            Color.Pink,
            Color.Purple,
            Color.Red,
            Color.Silver,
            Color.Teal,
            Color.White,
            Color.Wheat,
            Color.WhiteSmoke
        };

        private static readonly List<Font> Fonts = new List<Font>()
        {
            Font.Default.WithAttributes(FontAttributes.Bold),
            Font.Default.WithAttributes(FontAttributes.Italic),
            Font.Default.WithAttributes(FontAttributes.Bold | FontAttributes.Italic),
            Font.Default.WithAttributes(FontAttributes.None)
        };

        private static readonly List<BadgePosition> Positions = Enum.GetValues(typeof(BadgePosition)).Cast<BadgePosition>().ToList();

        public Color BadgeColor { get; private set; }
        public Color BadgeTextColor { get; private set; }

        public ICommand ChangeColorCommand => new Command((obj) =>
        {
            _color++;
            if (_color >= Colors.Count)
                _color = 0;

            BadgeColor = Colors[_color];
            RaisePropertyChanged(nameof(BadgeColor));
        });

        public ICommand ChangeTextColorCommand => new Command((obj) =>
        {
            _textColor--;
            if (_textColor < 0)
                _textColor = Colors.Count - 1;

            BadgeTextColor = Colors[_textColor];
            RaisePropertyChanged(nameof(BadgeTextColor));
        });

        public ICommand ChangeFontAttributesCommand => new Command((obj) =>
        {
            _fontIndex++;
            if (_fontIndex >= Fonts.Count)
                _fontIndex = 0;
            BadgeFont = Fonts[_fontIndex];
            RaisePropertyChanged(nameof(BadgeFont));
        });

        public ICommand ChangePositionCommand => new Command((obj) =>
        {
            _positionIndex++;
            if (_positionIndex >= Positions.Count)
                _positionIndex = 0;
            Position = Positions[_positionIndex];
            RaisePropertyChanged(nameof(Position));
        });

        private int _color = 0;
        private int _count = 0;
        private int _textColor = 0;
        private int _fontIndex = 0;
        private int _positionIndex = 0;

        public string Count => _count <= 0 ? string.Empty : _count.ToString();

        public int CountValue
        {
            get { return _count; }
            set
            {
                if (_count == value)
                    return;

                _count = value;
                RaisePropertyChanged(nameof(CountValue));
                RaisePropertyChanged(nameof(Count));
            }
        }

        public Font BadgeFont { get; private set; }
        public BadgePosition Position { get; private set; }

        private int _marginLeft = (int)TabBadge.GetDefaultMargins().Left;
        public int MarginLeft
        {
            get { return _marginLeft; }
            set
            {
                _marginLeft = value;
                RaisePropertyChanged(nameof(MarginLeft));
                RaisePropertyChanged(nameof(Margin));
            }
        }

        private int _marginTop = (int)TabBadge.GetDefaultMargins().Top;
        public int MarginTop
        {
            get { return _marginTop; }
            set
            {
                _marginTop = value;
                RaisePropertyChanged(nameof(MarginTop));
                RaisePropertyChanged(nameof(Margin));
            }
        }

        private int _marginRight = (int)TabBadge.GetDefaultMargins().Right;
        public int MarginRight
        {
            get { return _marginRight; }
            set
            {
                _marginRight = value;
                RaisePropertyChanged(nameof(MarginRight));
                RaisePropertyChanged(nameof(Margin));
            }
        }

        private int _marginBottom = (int)TabBadge.GetDefaultMargins().Bottom;
        public int MarginBottom
        {
            get { return _marginBottom; }
            set
            {
                _marginBottom = value;
                RaisePropertyChanged(nameof(MarginBottom));
                RaisePropertyChanged(nameof(Margin));
            }
        }

        public Thickness Margin => new Thickness(_marginLeft, _marginTop, _marginRight, _marginBottom);
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
