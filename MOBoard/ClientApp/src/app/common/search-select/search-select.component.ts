import { Component, OnInit, Input } from '@angular/core';

@Component({
	selector: 'app-search-select',
	templateUrl: './search-select.component.html',
	styleUrls: [ './search-select.component.scss' ]
})
export class SearchSelectComponent implements OnInit {
	public isShow: boolean = false;
	@Input() close: boolean;
	constructor() {}

	ngOnInit() {}

	toggleDisplay() {
		this.isShow = !this.isShow;
	}
}
