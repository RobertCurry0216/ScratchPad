using System;
using System.Diagnostics;
using Terminal.Gui;

namespace ScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();

            // I've just added dummy buttons in for now
            // Quit is the only one that does anything
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem [] {
                    new MenuItem ("_New", "", () => { }),
                    new MenuItem ("_Save", "", () => { }),
                    new MenuItem ("_Load", "", () => { }),
                    new MenuItem ("_Quit", "", () => {Application.RequestStop ();})
                }),
            });


            // I want to have a running history of snips added
            // and be able to scroll through them
            var historyWindow = new Window("History")
            {
                X = 0,
                Y = 1,
                Width = 15,
                Height = Dim.Fill()
            };

            // This is where I'll have the copy / paste buttons
            var buttonsWindow = new Window("Buttons")
            {
                X = 15,
                Y = 1,
                Width = Dim.Fill(),
                Height = 8
            };

            // Teh actual text window
            var scratchWindow = new Window("Scratch")
            {
                X = 15,
                Y = 9,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            // There was a bug where shrinking the window would cover the 
            // history panel, this was the only thing I could figure to fix it
            Application.Resized = (Application.ResizedEventArgs args) =>
            {
                historyWindow.Width = 15;
                buttonsWindow.X = 15;
                scratchWindow.X = 15;
            };

            // Add both menu and win in a single call
            Application.Top.Add(menu, historyWindow, buttonsWindow, scratchWindow);
            Application.Run();
        }
    }
    
}
