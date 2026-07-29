package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.HorarioAtencion;
import com.utp.sistemas.services.HorarioAtencionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/horarios-atencion")
public class HorarioAtencionController {

    @Autowired
    private HorarioAtencionService horarioAtencionService;

    @PostMapping
    public HorarioAtencion createHorarioAtencion(@RequestBody HorarioAtencion horarioAtencion) {
        return horarioAtencionService.createHorarioAtencion(horarioAtencion);
    }

    @GetMapping
    public List<HorarioAtencion> getAllHorariosAtencion() {
        return horarioAtencionService.getAllHorariosAtencion();
    }

    @GetMapping("/{id}")
    public ResponseEntity<HorarioAtencion> getHorarioAtencionById(@PathVariable Integer id) {
        return horarioAtencionService.getHorarioAtencionById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<HorarioAtencion> updateHorarioAtencion(@PathVariable Integer id, @RequestBody HorarioAtencion horarioAtencionDetails) {
        HorarioAtencion updatedHorarioAtencion = horarioAtencionService.updateHorarioAtencion(id, horarioAtencionDetails);
        return updatedHorarioAtencion != null ? ResponseEntity.ok(updatedHorarioAtencion) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteHorarioAtencion(@PathVariable Integer id) {
        horarioAtencionService.deleteHorarioAtencion(id);
        return ResponseEntity.noContent().build();
    }
}