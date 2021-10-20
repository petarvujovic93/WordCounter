import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-word-counter',
  templateUrl: './word-counter.component.html',
  styleUrls: ['./word-counter.component.css']
})
export class WordCounterComponent implements OnInit {
  resultvalue: number = 0;
  textInput: string = '';
  selectedOption: number = 0;
  displayResult: boolean = false;
  _httpClient: HttpClient;
  _baseUrl: string;
  file: File;

  options = [
    { value: 0, text: "" },
    { value: 1, text: "Count words from imput" },
    { value: 2, text: "Count words from database" },
    { value: 3, text: "Count words from txt file" }
  ];

  constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._httpClient = httpClient;
    this._baseUrl = baseUrl;
  }

  ngOnInit(): void {
  }



  onSelectItem(item) {
    this.selectedOption = item.value;
    this.displayResult = false;
  }

  onFileSelected(event) {
    this.file = event.target.files[0];
  }

  public CountFromInput() {
    const formData = new FormData();
    formData.append("textInput", this.textInput);
    this._httpClient.post(this._baseUrl + 'WordCounter/CountFromInput', formData)
      .subscribe(response => {
        console.log(response);
        this.resultvalue = response as number;
        this.displayResult = true;
      });
  }

  public CountFromDB() {
    this._httpClient.post(this._baseUrl + 'WordCounter/CountFromDB', new FormData())
      .subscribe(response => {
        this.resultvalue = response as number;
        this.displayResult = true;
      });
  }

  public CountFromFile() {
    const formData = new FormData();
    formData.append("file", this.file);
    console.log(this.file);
    this._httpClient.post(this._baseUrl + 'WordCounter/CountFromFile', formData)
      .subscribe(response => {
        this.resultvalue = response as number;
        this.displayResult = true;
      });
  }
}
