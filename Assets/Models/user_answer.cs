public class user_answer
{
    public int id { get; set; }
    public int id_user { get; set; }
    public int id_answer { get; set; }
    public int id_question { get; set; }

    public user_answer(int id_user, int id_answer, int id_question)
    {
        this.id = 0;
        this.id_user = id_user;
        this.id_answer = id_answer;
        this.id_question = id_question;
    }
    public user_answer() { }
}
