using System.Collections.Generic;

public class answer
{
    public int id_answer { get; set; }
    public string a_text { get; set; }
    public bool is_correct { get; set; }
    public int id_question { get; set; }
}

public class Root
{
    public List<answer> answer { get; set; }
}