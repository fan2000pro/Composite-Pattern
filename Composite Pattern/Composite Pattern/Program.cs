using System;
using System.Collections.Generic;

public interface IDocumentComponent
{
    void Add(IDocumentComponent component);
    void Remove(IDocumentComponent component);
    void Display(int indent = 0);
}

public class Paragraph : IDocumentComponent
{
    private string _text;

    public Paragraph(string text)
    {
        _text = text;
    }

    public void Add(IDocumentComponent component)
    {
        throw new NotSupportedException("Невозможно добавить компонент в абзац.");
    }

    public void Remove(IDocumentComponent component)
    {
        throw new NotSupportedException("Невозможно удалить компонент из абзаца.");
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + _text);
    }
}

public class Section : IDocumentComponent
{
    private string _title;
    private List<IDocumentComponent> _components = new List<IDocumentComponent>();

    public Section(string title)
    {
        _title = title;
    }

    public void Add(IDocumentComponent component)
    {
        _components.Add(component);
    }

    public void Remove(IDocumentComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + _title);
        foreach (var component in _components)
        {
            component.Display(indent + 2);
        }
    }
}

public class Document : IDocumentComponent
{
    private List<IDocumentComponent> _sections = new List<IDocumentComponent>();

    public void Add(IDocumentComponent component)
    {
        _sections.Add(component);
    }

    public void Remove(IDocumentComponent component)
    {
        _sections.Remove(component);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine("Структура документа:");
        foreach (var section in _sections)
        {
            section.Display(indent + 2);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Document document = new Document();

        Section section1 = new Section("Введение");
        section1.Add(new Paragraph("Это вводный параграф."));

        Section section2 = new Section("Основное содержание");
        section2.Add(new Paragraph("Первый параграф основного содержания."));
        Section subSection = new Section("Подраздел");
        subSection.Add(new Paragraph("Это параграф в подразделе."));
        section2.Add(subSection);

        Section section3 = new Section("Заключение");
        section3.Add(new Paragraph("Это заключительный параграф."));

        document.Add(section1);
        document.Add(section2);
        document.Add(section3);

        document.Display();
    }
}