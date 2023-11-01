import { Component } from '@angular/core';

import * as signalR from "@microsoft/signalr";

import * as Highcharts from "highcharts";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  connection : signalR.HubConnection ;
  
  constructor() {
    this.chart = {} as Highcharts.Chart;
    this.connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7122/satishub")
    .build();
    
    this.connection.start();

    this.connection.on("receiveMessage", datas => {
      this.chart.showLoading();
      for (let i = 0; i < this.chart.series.length; i++) {
        this.chart.series[i].remove();
      }
      for(let i = 0; i < datas.length; i++){
        this.chart.addSeries(datas[i]);
      }

      this.updateFromInput = true;
      this.chart.hideLoading();
    });

    const self = this;
    this.chartCallBack = (chart : Highcharts.Chart)=> {
      self.chart = chart;
    }

  }

  chart: Highcharts.Chart;
  updateFromInput= false;
  chartCallBack;


  Highcharts : typeof Highcharts = Highcharts;
  chartOptions : Highcharts.Options = {
    title:{
      text : "Başlık"
    },
    subtitle:{
      text: "Alt başlık"
    },
    yAxis:{
      title:{
        text: "TL SATIŞ YAPILDI"
      }
    },
    xAxis:{
      title:{
        text: "AYLIK SATIŞ"
      },
      accessibility:{
        rangeDescription: "2019-2020"
      }
    },
    legend:{
      layout:"vertical",
      align:"right",
      verticalAlign:"middle"
    },
    plotOptions:{
      series:{
        label:{
          connectorAllowed: true
        },
        pointStart: 1
      }
    }
  } as Highcharts.Options;
}
