import { Component, OnInit, ElementRef } from '@angular/core';

@Component({
	selector: 'app-modal',
	templateUrl: './modal.component.html',
	styleUrls: [ './modal.component.scss' ]
})
export class ModalComponent implements OnInit {
	shouldShow = false;
	constructor(private el: ElementRef) {}

	ngOnInit() {
		// we added this so that when the backdrop is clicked the modal is closed.
	}

	open() {
		console.log('open', '');
		this.shouldShow = true;
	}

	close() {
		this.shouldShow = !this.shouldShow;
	}
}
