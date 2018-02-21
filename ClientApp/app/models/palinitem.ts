interface IPalinItem
{
    Id: number;
    Text: string;
    Hash: string;
}

export class PalinItem
{
    public Id: number = 0;
    public Text: string = "";
    public Hash: string = "";

    contructor(item: IPalinItem) {
        this.Id = item.Id;
        this.Text = item.Text;
        this.Hash = item.Hash;    
    }
}