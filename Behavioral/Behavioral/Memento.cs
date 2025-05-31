using System;
using System.Collections.Generic;

namespace Memento
{
    public static class MementoPattern
    {
        public static void Run()
        {
            var editor = new TextEditor();
            var history = new History();

            editor.Type("Hello, ");
            history.Save(editor.Save());

            editor.Type("world!");
            history.Save(editor.Save());

            editor.Type(" Test.");
            editor.Show();

            Console.WriteLine("Rollback to a previous state...");
            editor.Restore(history.Undo());
            editor.Show();

            Console.WriteLine("Another rollback...");
            editor.Restore(history.Undo());
            editor.Show();
        }

        private class EditorMemento
        {
            public string Text { get; }

            public EditorMemento(string text)
            {
                Text = text;
            }
        }

        private class TextEditor
        {
            public string Text { get; private set; } = "";

            public void Type(string newText) => Text += newText;

            public EditorMemento Save() => new EditorMemento(Text);

            public void Restore(EditorMemento memento) => Text = memento.Text;

            public void Show() => Console.WriteLine($"Current text: \"{Text}\"");
        }

        private class History
        {
            private readonly Stack<EditorMemento> _history = new();

            public void Save(EditorMemento memento) => _history.Push(memento);

            public EditorMemento Undo() => _history.Pop();
        }
    }
}
