using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using Lab4.Models;

namespace Lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RomanNumberExtend? romanBuffer;
        private string calcText = "";
        private string operation = "";
        private bool isSomethingWrong = false;
        public MainWindowViewModel()
        {
            TakeLetters = ReactiveCommand.Create((string newLetter) =>
            {
                if (isSomethingWrong)
                {
                    DisplayText = "";
                    isSomethingWrong = false;
                }

                return DisplayText += newLetter;
            });
            TakeOperations = ReactiveCommand.Create((string newOperation) =>
            {
                if (isSomethingWrong)
                {
                    DisplayText = "";
                    isSomethingWrong = false;
                }

                romanBuffer = new RomanNumberExtend(DisplayText);
                DisplayText = "";

                return operation = newOperation;
            });
            TakeEqual = ReactiveCommand.Create(() =>
            {
                try
                {
                    var secondRoman = new RomanNumberExtend(DisplayText);

                    var a1 = new RomanNumber(romanBuffer.getNumber());
                    var a2 = new RomanNumber(secondRoman.getNumber());

                    switch (operation)
                    {
                        case "+":
                            {
                                DisplayText = (a1 + a2).ToString();
                                break;
                            }
                        case "-":
                            {
                                DisplayText = (a1 - a2).ToString();
                                break;
                            }
                        case "*":
                            {
                                DisplayText = (a1 * a2).ToString();
                                break;
                            }
                        case "/":
                            {
                                DisplayText = (a1 / a2).ToString();
                                break;
                            }
                        default:
                            {
                                isSomethingWrong = true;
                                calcText = "";
                                operation = "";
                                romanBuffer = null;
                                DisplayText = "Try again!";
                                break;
                            }
                    }
                }
                catch (RomanNumberException exception)
                {
                    isSomethingWrong = true;
                    calcText = "";
                    operation = "";
                    romanBuffer = null;
                    DisplayText = "Try again!";
                }

                return;
            });
        }
        public string DisplayText
        {
            set
            {
                this.RaiseAndSetIfChanged(ref calcText, value);
            }
            get
            {
                return calcText;
            }
        }

        public ReactiveCommand<string, string> TakeLetters { get; }
        public ReactiveCommand<string, string> TakeOperations { get; }
        public ReactiveCommand<Unit, Unit> TakeEqual { get; }
    }
}
